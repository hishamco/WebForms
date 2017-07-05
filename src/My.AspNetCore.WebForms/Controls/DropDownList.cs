using My.AspNetCore.WebForms.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace My.AspNetCore.WebForms.Controls
{
    // TODO: Use proper property ( Text or Value ), when we support data binding
    public class DropDownList : Control, IPostBackDataHandler
    {
        public event EventHandler SelectedIndexChanged;

        public bool AutoPostBack { get; set; }

        public bool Enabled { get; set; } = true;

        public IList<ListItem> Items { get; set; }

        public int SelectedIndex
        {
            get
            {
                var item = Items.SingleOrDefault(i => i.Selected);
                return Items.IndexOf(item);
            }
            set
            {
                if (value >= Items.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                Items[value].Selected = true;
            }
        }

        public ListItem SelectedItem => SelectedIndex == -1 ? null : Items[SelectedIndex];

        public string SelectedValue {
            get
            {
                return SelectedIndex == -1 ? string.Empty : Items[SelectedIndex].Text;
            }
            set
            {
                var item = Items.SingleOrDefault(i => i.Text == value);
                SelectedIndex = Items.IndexOf(item);
            }
        }

        public string Text { get; set; }

        public void LoadPostData(IDictionary<string, string> postBackData)
        {
            var currentSelectedValue = SelectedItem?.Text;
            var postData = string.Empty;

            if (postBackData.ContainsKey(Name))
            {
                postData = postBackData[Name];
            }

            if (Enabled && currentSelectedValue != postData)
            {
                SelectedValue = postData;
                OnSelectedIndexChanged(EventArgs.Empty);
            }
        }

        public async override Task RenderAsync(TextWriter writer)
        {
            var tagName = "select";
            var tagBuilder = new TagBuilder(tagName)
            {
                TagRenderMode = TagRenderMode.StartTag
            };

            tagBuilder.Attributes.Add("name", Name);

            if (AutoPostBack)
            {
                tagBuilder.Attributes.Add("onchange", "this.form.submit()");
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

            foreach (var item in Items)
            {
                item.Name = Name;
                if (SelectedValue != null)
                {
                    item.Selected = (item.Text == SelectedValue);
                }
                await item.RenderAsync(writer);
            }

            tagBuilder = new TagBuilder(tagName)
            {
                TagRenderMode = TagRenderMode.EndTag
            };
            tagBuilder.WriteTo(writer, HtmlEncoder.Default);
            await Task.CompletedTask;
        }

        protected virtual void OnSelectedIndexChanged(EventArgs e)
        {
            SelectedIndexChanged?.Invoke(this, e);
        }
    }
}
