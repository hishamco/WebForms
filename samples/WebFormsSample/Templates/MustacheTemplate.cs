using My.AspNetCore.WebForms.Templating;

namespace WebFormsSample.Templates
{
    public class MustacheTemplate : Template
    {
        public override string Parse(string template, dynamic model)
        {
            var result = Nustache.Core.Render.StringToString(template,
                new { ApplicationName = "ASP.NET Core Web Forms", Title = model.Title });

            return result;
        }
    }
}
