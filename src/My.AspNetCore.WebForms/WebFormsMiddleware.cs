using Microsoft.AspNetCore.Http;
using My.AspNetCore.WebForms.Infrastructure;
using System;
using System.Threading.Tasks;

namespace My.AspNetCore.WebForms
{
    public class WebFormsMiddleware
    {
        private readonly IPageFactory _pageFactory;
        private readonly RequestDelegate _next;

        public WebFormsMiddleware(IPageFactory pageFactory, RequestDelegate next)
        {
            if (pageFactory == null)
            {
                throw new ArgumentNullException(nameof(pageFactory));
            }

            if (next == null)
            {
                throw new ArgumentNullException(nameof(next));
            }

            _pageFactory = pageFactory;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Pesky browsers
            if (context.Request.Path.Value.EndsWith("favicon.ico"))
            {
                context.Response.StatusCode = 404;
                return;
            }

            var path = context.Request.Path.Value
                .TrimStart(new char[] { '/' });

            if (path == "")
            {
                path = "Index";
            }

            var page = (Page)_pageFactory.CreatePage(path);

            page.Context = context;
            await page.RenderAsync();
        }
    }
}
