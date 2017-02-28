using System.Threading.Tasks;

namespace My.AspNetCore.WebForms.Templating
{
    public abstract class Template : ITemplate
    {
        public virtual Task<string> ParseAsync(string template, dynamic model)
        {
            var result = Parse(template, model);
            return Task.FromResult<string>(result);
        }

        public virtual string Parse(string template, dynamic model)
        {
            return template;
        }
    }
}
