using System.Linq;
using System.IO;
using System.Threading.Tasks;
using My.AspNetCore.WebForms.Controls;

namespace My.AspNetCore.WebForms.Rendering
{
    public class ControlRendering : IControlRendering
    {
        // TODO: Improve the string lookup & manipulation by introduce control parser
        public async Task RenderAsync(Page page, string markup, TextWriter writer)
        {
            var startTagIndex = markup.IndexOf($"<{Control.TagPrefix}");
            var endTagIndex = markup.IndexOf($"</{Control.TagPrefix}");
            var postEndTagIndex = markup.IndexOf('>', endTagIndex) + 1;
            var controlMarkup = markup.Substring(startTagIndex, postEndTagIndex - startTagIndex);
            var nameStartIndex = controlMarkup.IndexOf("Name=") + 6;
            var quoteLastIndex = controlMarkup.IndexOf('"', nameStartIndex);
            var controlName = controlMarkup.Substring(nameStartIndex, quoteLastIndex - nameStartIndex);
            var control = page.Controls.SingleOrDefault(c => c.Name == controlName);
            
            // Render any content before the control
            await writer.WriteAsync(markup.Substring(0, startTagIndex));
            // Render the actual control
            await control.RenderAsync(writer);
            // Render any content after the control
            await writer.WriteAsync(markup.Substring(postEndTagIndex));
        }
    }
}
