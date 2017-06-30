using Microsoft.AspNetCore.Hosting;
using My.AspNetCore.WebForms.Templating;
using RazorLight;
using RazorLight.Extensions;

namespace WebFormsSampleCS.Templates
{
    public class RazorTemplate : Template
    {
        private IHostingEnvironment _hostingEnvironment;

        public RazorTemplate(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public override string Parse(string template, dynamic model)
        {
            var root = _hostingEnvironment.WebRootPath;
            var engine = EngineFactory.CreatePhysical(root);
            var result = engine.ParseString(template,
                new { ApplicationName = "ASP.NET Core Web Forms", Title = model.Title });

            return result;
        }
    }
}
