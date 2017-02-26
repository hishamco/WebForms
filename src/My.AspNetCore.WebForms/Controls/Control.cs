using System.IO;
using System.Threading.Tasks;

namespace My.AspNetCore.WebForms.Controls
{
    public abstract class Control
    {
        public const string TagPrefix = "asp:";

        public string Name { get; set; }

        public abstract Task RenderAsync(TextWriter writer);
    }
}
