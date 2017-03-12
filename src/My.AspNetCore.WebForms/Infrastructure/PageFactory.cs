using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Reflection;

namespace My.AspNetCore.WebForms.Infrastructure
{
    public class PageFactory : IPageFactory
    {
        private readonly WebFormsOptions _webFormsOptions;
        private readonly IHostingEnvironment _hostingEnvironment;

        public PageFactory(IOptions<WebFormsOptions> webFormsOptions, IHostingEnvironment hostingEnvironment)
        {
            _webFormsOptions = webFormsOptions.Value;
            _hostingEnvironment = hostingEnvironment;
        }

        public Page CreatePage(string type)
        {
            var assembly = GetHostedApplicationAssembly();
            var pageFullyQualifiedName = (_webFormsOptions.PagesLocation == string.Empty ?
                $"{AppName}.{type}" :
                $"{AppName}.{_webFormsOptions.PagesLocation}.{type}");
            var pageType = assembly.GetType(pageFullyQualifiedName);

            if (pageType == null)
            {
                return null;
            }

            return (Page)Activator.CreateInstance(pageType);
        }

        private Assembly GetHostedApplicationAssembly() =>
            Assembly.Load(new AssemblyName(AppName));

        private string AppName => _hostingEnvironment.ApplicationName;
    }
}
