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
        private readonly IPageLoader _pageLoader;
        private readonly RequestDelegate _next;

        private static readonly char[] _separator = new char[] { '/' };

        public WebFormsMiddleware(
            IPageFactory pageFactory,
            IPageContextFactory pageContextFactory,
            IPageLoader pageLoader,
            RequestDelegate next)
        {
            _pageFactory = pageFactory ?? throw new ArgumentNullException(nameof(pageFactory));
            _pageLoader = pageLoader ?? throw new ArgumentNullException(nameof(pageLoader));
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

            var relativePath = context.Request.Path.Value.TrimStart(_separator);
            if (relativePath == string.Empty)
            {
                relativePath = "Index";
            }

            if (relativePath.EndsWith(Page.Extension))
            {
                var extensionIndex = relativePath.LastIndexOf(Page.Extension);
                relativePath = relativePath.Remove(extensionIndex);
            }

            var pageContext = _pageContextFactory.Create(context);
            var pageType = _pageLoader.Load(relativePath);
            if (pageType == null)
            {
                context.Response.StatusCode = 404;
                return;
            }

            var pageDescriptor = new PageDescriptor
            {
                RelativePath = relativePath,
                PageType = pageType
            };

            pageContext.PageDescriptor = pageDescriptor;

            var page = _pageFactory.CreatePage(pageContext);
            await page.ExecuteAsync();
        }
    }
}
