using Microsoft.AspNetCore.Http;

namespace My.AspNetCore.WebForms.Infrastructure
{
    public class DefaultPageContextFactory : IPageContextFactory
    {
        public PageContext Create(HttpContext context)
        {
            var pageContext = new PageContext()
            {
                HttpContext = context
            };

            return pageContext;
        }
    }
}
