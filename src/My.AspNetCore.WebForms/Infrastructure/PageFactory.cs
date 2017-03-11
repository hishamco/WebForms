using Microsoft.Extensions.Options;
using System;
using System.Reflection;

namespace My.AspNetCore.WebForms.Infrastructure
{
    public class PageFactory : IPageFactory
    {
        private readonly WebFormsOptions _webFormsOptions;

        public PageFactory(IOptions<WebFormsOptions> webFormsOptions)
        {
            _webFormsOptions = webFormsOptions.Value;
        }

        public Page CreatePage(string type)
        {
            var assembly = Assembly.GetEntryAssembly();
            var pageFullyQualifiedName = string.Join(".",
                assembly.GetName().Name, _webFormsOptions.PagesLocation, type);
            var pageType = assembly.GetType(pageFullyQualifiedName);

            if (pageType == null)
            {
                return null;
            }

            return (Page)Activator.CreateInstance(pageType);
        }
    }
}
