using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Reflection;

namespace My.AspNetCore.WebForms.Infrastructure
{
    public class DefaultPageLoader : IPageLoader
    {
        private readonly WebFormsOptions _webFormsOptions;
        private readonly IHostingEnvironment _hostingEnvironment;

        public DefaultPageLoader(
            IOptions<WebFormsOptions> webFormsOptions,
            IHostingEnvironment hostingEnvironment)
        {
            _webFormsOptions = webFormsOptions.Value;
            _hostingEnvironment = hostingEnvironment;
        }

        public Type Load(string relativePath)
        {
            var assembly = GetHostedApplicationAssembly();
            var pageFullyQualifiedName = (_webFormsOptions.PagesLocation == string.Empty ?
                $"{AppName}.{relativePath}" :
                $"{AppName}.{_webFormsOptions.PagesLocation}.{relativePath}");

            return assembly.GetType(pageFullyQualifiedName);
        }

        private Assembly GetHostedApplicationAssembly() =>
            Assembly.Load(new AssemblyName(AppName));

        private string AppName => _hostingEnvironment.ApplicationName;
    }
}
