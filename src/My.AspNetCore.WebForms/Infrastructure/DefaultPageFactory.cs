using System;

namespace My.AspNetCore.WebForms.Infrastructure
{
    public class DefaultPageFactory : IPageFactory
    {
        public Page CreatePage(PageContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var pageType = context.PageDescriptor?.PageType ?? null;
            if (pageType == null)
            {
                return null;
            }

            var page = (Page)Activator.CreateInstance(pageType);
            page.Context = context;

            return page;
        }
    }
}
