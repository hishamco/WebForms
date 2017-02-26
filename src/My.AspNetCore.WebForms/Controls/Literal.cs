using System.IO;
using System.Threading.Tasks;

namespace My.AspNetCore.WebForms.Controls
{
    public class Literal : Control
    {
        public string Text { get; set; }

        public async override Task RenderAsync(TextWriter writer)
        {
            if (Text?.Length > 0)
            {
                await writer.WriteAsync(Text);
            }
        }
    }
}
