using My.AspNetCore.WebForms;
using My.AspNetCore.WebForms.Templating;

namespace WebFormsSample.Templates
{
    public class SimpleTemplate : Template
    {
        public override string Parse(string template, dynamic model)
        {
            // For the sake of the demo I'm looking for {{title}} only
            // but we can go further to evaluate all the public properties using Reflection 
            var page = (Page)model;
            var result = template.Replace("{{title}}", page.Title);

            return result;
        }
    }
}
