using Microsoft.AspNetCore.Http;
using My.AspNetCore.WebForms.Infrastructure;
using System;
using System.Threading.Tasks;

namespace My.AspNetCore.WebForms
{
    public class WebFormsMiddleware
    {
        private readonly IPageFactory _pageFactory;
        private readonly IPageContextFactory _pageContextFactory;
        private readonly RequestDelegate _next;

        private static readonly char[] _separator = new char[] { '/' };

        public WebFormsMiddleware(
            IPageFactory pageFactory,
            IPageContextFactory pageContextFactory,
            RequestDelegate next)
        {
            _pageFactory = pageFactory ?? throw new ArgumentNullException(nameof(pageFactory));
            _pageContextFactory = pageContextFactory ?? throw new ArgumentNullException(nameof(pageContextFactory));
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

            var path = context.Request.Path.Value.TrimStart(_separator);

            if (path == string.Empty)
            {
                path = "Index";
            }

            var page = _pageFactory.CreatePage(path);

            if (page == null)
            {
                context.Response.StatusCode = 404;
                return;
            }

            page.Context = _pageContextFactory.Create(context);
            await page.ExecuteAsync();
        }
    }
}
