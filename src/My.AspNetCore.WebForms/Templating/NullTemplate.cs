using System.Threading.Tasks;

namespace My.AspNetCore.WebForms.Templating
{
    internal class NullTemplate : Template
    {
        public async override Task<string> ParseAsync(string template, dynamic model) =>
            await Task.FromResult(template);
    }
}
