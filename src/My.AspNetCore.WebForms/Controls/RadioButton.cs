using My.AspNetCore.WebForms.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace My.AspNetCore.WebForms.Controls
{
    public class RadioButton : CheckBox, IPostBackDataHandler
    {
        public string GroupName { get; set; }

        public new void LoadPostData(IDictionary<string, string> postBackData)
        {
            var currentChecked = Checked;
            var postData = false;
            var name = GroupName ?? Name;
            if (postBackData.ContainsKey(name))
            {
                postData = postBackData[name] == Name;
            }

            if (Enabled && currentChecked != postData)
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

        private void RenderInput(TextWriter writer)
        {
            var tagName = "input";
            var tagBuilder = new TagBuilder(tagName)
            {
                TagRenderMode = TagRenderMode.SelfClosing
            };

            tagBuilder.Attributes.Add("name", GroupName ?? Name);
            tagBuilder.Attributes.Add("type", "radio");
            tagBuilder.Attributes.Add("value", Name);

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
