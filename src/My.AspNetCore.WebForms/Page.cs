using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace My.AspNetCore.WebForms
{
    public abstract class Page
    {
        public event EventHandler Load;

        protected internal string Content { get; set; }

        protected internal HttpContext Context { get; set; }

        public async virtual Task RenderAsync()
        {
            OnLoad();

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

            Context.Response.StatusCode = 200;
            Context.Response.ContentType = "text/html; charset=utf-8";
            await Context.Response.WriteAsync(Content);
        }

        protected virtual void OnLoad()
        {
            Load?.Invoke(this, EventArgs.Empty);
        }
    }
}
