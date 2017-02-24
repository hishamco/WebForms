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
            _pageFactory = pageFactory ?? throw new ArgumentNullException(nameof(pageFactory));
            _next = next ?? throw new ArgumentNullException(nameof(next));
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

            var page = _pageFactory.CreatePage(path);

            if (page == null)
            {
                context.Response.StatusCode = 404;
                return;
            }

            page.Context = context;
            await page.RenderAsync();
        }
    }
}
