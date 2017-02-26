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
        private Button _postBackSender;

        public event EventHandler Load;

        protected internal string Content { get; set; }

        protected internal HttpContext Context { get; set; }

        public IList<Control> Controls { get; } = new List<Control>();

        public bool IsPostBack => Context.Request.Method == "POST";

        public async Task ExecuteAsync()
        {
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

            OnLoad();

            if (IsPostBack)
            {
                GetPostedData();
                ExecutePostBackCode();
            }

            await RenderAsync();
        }

        public async virtual Task RenderAsync()
        {
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

        private void GetPostedData()
        {
            foreach (var ctrl in Controls)
            {
                var form = Context.Request.Form;

                if (form.ContainsKey(ctrl.Id))
                {
                    switch (ctrl.GetType().Name)
                    {
                        case "Button":
                            _postBackSender = (Button)ctrl;
                            break;
                        case "TextBox":
                            ((TextBox)ctrl).Text = form[ctrl.Id].ToString();
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void ExecutePostBackCode()
        {
            if (_postBackSender != null)
            {
                _postBackSender.GetType()
                    .GetMethod("OnClick", BindingFlags.Instance | BindingFlags.NonPublic)
                    .Invoke(_postBackSender, null);
            }
        }
    }
}
