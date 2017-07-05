using HtmlAgilityPack;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using My.AspNetCore.WebForms.Controls;
using My.AspNetCore.WebForms.Rendering;
using My.AspNetCore.WebForms.Templating;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.AspNetCore.WebForms
{
    public abstract class Page
    {
        private string _content;
        private PageContext _context;

        public static readonly string Extension = ".aspx";

        public event PageLoadEventHandler Load;

        public PageContext Context
        {
            get => _context;

            internal set
            {
                _context = value ?? throw new ArgumentException(nameof(value));
                _context.Page = this;
            }
        }

        public ControlCollection Controls { get; } = new ControlCollection();

        public string Title { get; set; }

        public ILogger Logger { get; private set; }

        public async Task ExecuteAsync()
        {
            var loggerFactory = ((ILoggerFactory)Context.HttpContext
                .RequestServices.GetService(typeof(ILoggerFactory)));
            Logger = loggerFactory.CreateLogger(GetType().FullName);

            var pageName = GetType().Name + Extension;
            var pagesLocation = ((IOptions<WebFormsOptions>)Context.HttpContext.RequestServices
                .GetService(typeof(IOptions<WebFormsOptions>))).Value.PagesLocation;
            var path = Path.Combine(pagesLocation, pageName);
            var fileInfo = ((IHostingEnvironment)Context.HttpContext.RequestServices
                .GetService(typeof(IHostingEnvironment))).ContentRootFileProvider
                .GetFileInfo(path);

            using (var readStream = fileInfo.CreateReadStream())
            using (var reader = new StreamReader(readStream))
            {
                _content = await reader.ReadToEndAsync();
            }

            var args = new PageLoadEventArgs(Context);

            OnLoad(args);

            if (args.IsPostBack)
            {
                var postBackData = Context.HttpContext.Request.Form.ToDictionary(i => i.Key, i=> i.Value.ToString());
                var postBackEventHandlers = Controls
                    .Where(c => c.GetType().GetInterfaces()
                    .Contains(typeof(IPostBackEventHandler))).ToList();
                // HACK: Allow postBackEventHandler to be nullable to let AutoPostBack property work as well
                var postBackEventHandler = (IPostBackEventHandler)postBackEventHandlers
                    .SingleOrDefault(c => postBackData.ContainsKey(c.Name));

                RaisePostBackDataEvent(postBackData);

                if (postBackEventHandler != null)
                {
                    RaisePostBackEvent(postBackEventHandler);
                }
            }

            await RenderAsync();
        }

        public async virtual Task RenderAsync()
        {
            var doc = await RenderControlNodes();
            var template = (ITemplate) Context.HttpContext.RequestServices.GetService(typeof(ITemplate));
            var renderedContent = await template.ParseAsync(doc.DocumentNode.InnerHtml, this);

            Context.HttpContext.Response.StatusCode = 200;
            Context.HttpContext.Response.ContentType = "text/html; charset=utf-8";
            await Context.HttpContext.Response.WriteAsync(renderedContent);
        }

        protected virtual void OnLoad(PageLoadEventArgs e)
        {
            Load?.Invoke(this, e);
        }

        private void RaisePostBackDataEvent(IDictionary<string, string> postBackData)
        {
            var postBackDataHandlers = Controls
                .Where(c => c.GetType().GetInterfaces()
                .Contains(typeof(IPostBackDataHandler))).ToList();

            postBackDataHandlers.ForEach(c => ((IPostBackDataHandler)c).LoadPostData(postBackData));
        }

        private void RaisePostBackEvent(IPostBackEventHandler control)
        {
            control.RaisePostBackEvent();
        }

        // HACK: return HtmlDocument because you can't have async methods with ref or out parameters.
        private async Task<HtmlDocument> RenderControlNodes()
        {
            var controlRendering = new ControlRendering();
            var doc = new HtmlDocument();

            doc.LoadHtml(_content);
            var nodes = doc.DocumentNode.SelectNodes($"//*[starts-with(name(),'{Control.TagPrefix}')]");

            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    using (var sw = new StringWriter(new StringBuilder()))
                    {
                        await controlRendering.RenderAsync(this, node.OuterHtml, sw);
                        var newNode = new HtmlDocument();
                        newNode.LoadHtml(sw.GetStringBuilder().ToString());
                        node.ParentNode.ReplaceChild(newNode.DocumentNode, node);
                    }
                }
            }

            return doc;
        }
    }
}
