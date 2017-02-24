using System;
using System.Reflection;

namespace My.AspNetCore.WebForms.Infrastructure
{
    public class PageFactory : IPageFactory
    {
        public Page CreatePage(string type)
        {
            var assembly = Assembly.GetEntryAssembly();
            var assemblyName = assembly.GetName().Name;
            var pagesFolder = "Pages";
            var pageFullName = string.Join(".", assemblyName, pagesFolder, type);
            var pageType = assembly.GetType(pageFullName);

            if (pageType == null)
            {
                return null;
            }

            return (Page)Activator.CreateInstance(pageType);
        }
    }
}
