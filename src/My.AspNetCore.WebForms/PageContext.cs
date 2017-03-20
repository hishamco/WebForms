using Microsoft.AspNetCore.Http;
using System;

namespace My.AspNetCore.WebForms
{
    public sealed class PageContext
    {
        private Page _page;
        private HttpContext _httpContext;

        public PageContext()
        {

        }

        public Page Page
        {
            get => _page;

            set => _page = value ?? throw new ArgumentNullException(nameof(value));
        }

        public HttpContext HttpContext
        {
            get => _httpContext;

            set =>_httpContext = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
