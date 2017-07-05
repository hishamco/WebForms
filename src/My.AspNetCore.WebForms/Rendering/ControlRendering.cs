using System.Linq;
using System.IO;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace My.AspNetCore.WebForms.Rendering
{
    public class ControlRendering : IControlRendering
    {
        public async Task RenderAsync(Page page, string markup, TextWriter writer)
        {
            var node = HtmlNode.CreateNode(markup);
            var controlName = node.Attributes["Name"]?.Value;
            var control = page.Controls.SingleOrDefault(c => c.Name == controlName);

            if (control != null)
            {
                await control.RenderAsync(writer);
            }
        }
    }
}
