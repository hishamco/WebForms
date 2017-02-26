using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using My.AspNetCore.WebForms.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace My.AspNetCore.WebForms
{
    public abstract class Page
    {
        private Button _postBackSender;
        private string _content;
        private HttpContext _context;

        public event EventHandler Load;

        protected internal HttpContext Context
        {
            get
            {
                return _context;
            }

            internal set
            {
                _context = value ?? throw new ArgumentException(nameof(Context));
            }
        }

        public IList<Control> Controls { get; } = new List<Control>();

        public bool IsPostBack => Context.Request.Method == "POST";

        public async Task ExecuteAsync()
        {
            var env = (IHostingEnvironment)Context.RequestServices
                .GetService(typeof(IHostingEnvironment));
            var pagesFolder = "Pages";
            const string htmlExtension = ".htm";
            var pageName = GetType().Name + htmlExtension;
            var path = Path.Combine(pagesFolder, pageName);
            var fileInfo = env.ContentRootFileProvider
                .GetFileInfo(path);

            using (var readStream = fileInfo.CreateReadStream())
            using (var reader = new StreamReader(readStream))
            {
                _content = await reader.ReadToEndAsync();
            }

            OnLoad();

            if (IsPostBack)
            {
                GetPostedData();
                ExecutePostBackCode();
            }

            await RenderAsync();
        }

        public async virtual Task RenderAsync()
        {
            var writer = new StringWriter(new StringBuilder());

            foreach (var line in _content.Split('\n'))
            {
                if (line.Contains("asp:"))
                {
                    await RenderControlAsync(line, writer);
                }
                else
                {
                    await writer.WriteAsync(line);
                }
            }

            Context.Response.StatusCode = 200;
            Context.Response.ContentType = "text/html; charset=utf-8";
            await Context.Response.WriteAsync(writer.GetStringBuilder().ToString());
        }

        protected virtual void OnLoad()
        {
            Load?.Invoke(this, EventArgs.Empty);
        }

        private async Task RenderControlAsync(string content, TextWriter writer)
        {
            var beginIndex = content.IndexOf("<asp:");
            var endIndex = content.IndexOf('>',
                content.IndexOf("</asp:")) + 1;

            await writer.WriteAsync(content.Substring(0, beginIndex - 1));
            var control = ParseControl(content.Substring(beginIndex, endIndex - beginIndex));
            await control.RenderAsync(writer);
            await writer.WriteAsync(content.Substring(endIndex));
        }

        // TODO: Parse the control from actual string
        private Control ParseControl(string content)
        {
            // Now it's fine to look for the control name in the Controls property
            var nameStartIndex = content.IndexOf("Name=") + 6;
            var quoteLastIndex = content.IndexOf('"', nameStartIndex);
            var name = content.Substring(nameStartIndex, quoteLastIndex - nameStartIndex);

            return Controls.SingleOrDefault(c => c.Name == name);
        }

        private void GetPostedData()
        {
            foreach (var ctrl in Controls)
            {
                var form = Context.Request.Form;

                if (form.ContainsKey(ctrl.Name))
                {
                    switch (ctrl.GetType().Name)
                    {
                        case nameof(Button):
                            _postBackSender = (Button)ctrl;
                            break;
                        case nameof(TextBox):
                            ((TextBox)ctrl).Text = form[ctrl.Name].ToString();
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void ExecutePostBackCode()
        {
            if (_postBackSender != null)
            {
                _postBackSender.GetType()
                    .GetMethod("OnClick", BindingFlags.Instance | BindingFlags.NonPublic)
                    .Invoke(_postBackSender, null);
            }
        }
    }
}
