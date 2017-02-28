using System.Threading.Tasks;

namespace My.AspNetCore.WebForms.Templating
{
    public interface ITemplate
    {
        Task<string> ParseAsync(string template, dynamic model);
    }
}
