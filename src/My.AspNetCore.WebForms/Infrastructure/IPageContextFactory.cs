using Microsoft.AspNetCore.Http;

namespace My.AspNetCore.WebForms.Infrastructure
{
    public interface IPageContextFactory
    {
        PageContext Create(HttpContext context);
    }
}
