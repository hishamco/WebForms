using System;
using System.Collections.Generic;
using System.Reflection;

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

            var pageConstructors = context.PageDescriptor.PageType
                .GetConstructors(BindingFlags.Public | BindingFlags.Instance);
            if (pageConstructors.Length != 1)
            {
                throw new InvalidOperationException("Page requires a single constructor");
            }

            var constructorParams = pageConstructors[0].GetParameters();
            var args = new List<object>();
            foreach (var param in constructorParams)
            {
                args.Add(context.HttpContext.RequestServices.GetService(param.ParameterType));
            }

            var page = (Page)Activator.CreateInstance(context.PageDescriptor.PageType, args.ToArray());
            page.Context = context;

            return page;
        }
    }
}
