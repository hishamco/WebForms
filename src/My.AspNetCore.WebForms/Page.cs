using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using My.AspNetCore.WebForms.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace My.AspNetCore.WebForms
{
    public abstract class Page
    {
        public event EventHandler Load;

        protected internal string Content { get; set; }

        protected internal HttpContext Context { get; set; }

        public IList<Control> Controls { get; set; } = new List<Control>();

        public bool IsPostBack => Context.Request.Method == "POST";

        public async virtual Task RenderAsync()
        {
            OnLoad();

            if (IsPostBack)
            {
                ExecutePostBackCode();
            }

            var env = (IHostingEnvironment)Context.RequestServices
                .GetService(typeof(IHostingEnvironment));
            var pagesFolder = "Pages";
            const string htmlExtension = ".htm";
            var pageName = GetType().Name + htmlExtension;
            var path = Path.Combine(pagesFolder, pageName);
            var fileInfo = env.ContentRootFileProvider
                .GetFileInfo(path);

            using (var readStream = fileInfo.CreateReadStream())
            using (var reader = new StreamReader(readStream))
            {
                Content = await reader.ReadToEndAsync();
            }

            RenderControls();

            Context.Response.StatusCode = 200;
            Context.Response.ContentType = "text/html; charset=utf-8";
            await Context.Response.WriteAsync(Content);
        }

        protected virtual void OnLoad()
        {
            Load?.Invoke(this, EventArgs.Empty);
        }

        private void RenderControls()
        {
            foreach (var ctrl in Controls)
            {
                ctrl.Render();

                var typeName = ctrl.GetType().Name;
                var startIndex = Content.IndexOf($"<asp:{typeName}");
                var endIndex = Content.IndexOf($"</asp:{typeName}>") + typeName.Length + 7;

                Content = Content.Replace(Content.Substring(startIndex, endIndex - startIndex), ctrl.InnerHtml);
            }
        }

        private void ExecutePostBackCode()
        {
            var sender = Controls.OfType<Button>()
                    .SingleOrDefault(c => Context.Request.Form.ContainsKey(c.Id));

            if (sender != null)
            {
                sender.GetType()
                    .GetMethod("OnClick", BindingFlags.Instance | BindingFlags.NonPublic)
                    .Invoke(sender, null);
            }
        }
    }
}
