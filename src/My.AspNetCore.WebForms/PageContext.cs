using Microsoft.AspNetCore.Http;
using System;

namespace My.AspNetCore.WebForms
{
    public sealed class PageContext
    {
        private Page _page;
        private PageDescriptor _pageDescriptor;
        private HttpContext _httpContext;

        public PageContext()
        {

        }

        public Page Page
        {
            get => _page;

            set => _page = value ?? throw new ArgumentNullException(nameof(value));
        }

        public PageDescriptor PageDescriptor
        {
            get => _pageDescriptor;

            set => _pageDescriptor = value ?? throw new ArgumentNullException(nameof(value));
        }

        public HttpContext HttpContext
        {
            get => _httpContext;

            set => _httpContext = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
