using My.AspNetCore.WebForms.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace My.AspNetCore.WebForms.Controls
{
    public class CheckBox : Control, IPostBackDataHandler
    {
        public event EventHandler CheckedChanged;

        public bool AutoPostBack { get; set; }

        public bool Checked { get; set; }

        public bool Enabled { get; set; } = true;

        public string Text { get; set; }

        public TextAlign TextAlign { get; set; } = TextAlign.Right;

        public void LoadPostData(IDictionary<string, string> postBackData)
        {
            var postData = postBackData.ContainsKey(Name);

            if (Enabled)
            {
                Checked = postData;
                OnCheckedChanged(EventArgs.Empty);
            }
        }

        public async override Task RenderAsync(TextWriter writer)
        {
            if (TextAlign == TextAlign.Right)
            {
                RenderInput(writer);
                RenderLabel(writer);
            }
            else
            {
                RenderLabel(writer);
                RenderInput(writer);
            }

            await Task.CompletedTask;
        }

        protected virtual void OnCheckedChanged(EventArgs e)
        {
            CheckedChanged?.Invoke(this, e);
        }

        private void RenderInput(TextWriter writer)
        {
            var tagName = "input";
            var tagBuilder = new TagBuilder(tagName)
            {
                TagRenderMode = TagRenderMode.SelfClosing
            };

            tagBuilder.Attributes.Add("name", Name);
            tagBuilder.Attributes.Add("type", "checkbox");

            if (AutoPostBack)
            {
                tagBuilder.Attributes.Add("onclick", "this.form.submit()");
            }

            if (Checked)
            {
                tagBuilder.Attributes.Add("checked", "checked");
            }

            if (!Enabled)
            {
                tagBuilder.Attributes.Add("disabled", "disabled");
            }

            if (!Visible)
            {
                tagBuilder.AddStyle(new Style { Attribute = "display", Value = "none" });
            }

            tagBuilder.WriteTo(writer, HtmlEncoder.Default);
        }

        private void RenderLabel(TextWriter writer)
        {
            var tagName = "label";
            var tagBuilder = new TagBuilder(tagName)
            {
                TagRenderMode = TagRenderMode.Normal
            };

            tagBuilder.Attributes.Add("for", Name);
            tagBuilder.InnerHtml.Append(Text);
            tagBuilder.WriteTo(writer, HtmlEncoder.Default);
        }
    }
}
