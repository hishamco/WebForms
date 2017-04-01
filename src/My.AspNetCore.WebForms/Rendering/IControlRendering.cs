using System.IO;
using System.Threading.Tasks;

namespace My.AspNetCore.WebForms.Rendering
{
    public interface IControlRendering
    {
        Task RenderAsync(Page page, string markup, TextWriter writer);
    }
}
