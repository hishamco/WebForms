using System;
using System.Reflection;

namespace My.AspNetCore.WebForms.Infrastructure
{
    public class PageFactory : IPageFactory
    {
        public Page CreatePage(string type)
        {
            var assemblyName = Assembly.GetEntryAssembly().GetName().Name;
            var pagesFolder = "Pages";
            var pageType = Assembly.GetEntryAssembly()
                .GetType(string.Join(".", assemblyName, pagesFolder, type));

            return (Page)Activator.CreateInstance(pageType);
        }
    }
}
