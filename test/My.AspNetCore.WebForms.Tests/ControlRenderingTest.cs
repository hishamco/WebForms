using My.AspNetCore.WebForms.Controls;
using My.AspNetCore.WebForms.Rendering;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace My.AspNetCore.WebForms.Tests
{
    public class ControlRenderingTest
    {
        [Fact]
        public async Task RenderControl()
        {
            // Arrange
            var controlRendering = new ControlRendering();
            var page = new TestPage();
            var markup = "<asp:Literal Name=\"litPostBack\" Text=\"IsPostBack: False\"></asp:Literal>";
            var writer = new StringWriter(new StringBuilder());
            
            // Act
            await controlRendering.RenderAsync(page, markup, writer);

            // Assert
            Assert.Equal("IsPostBack: False", writer.GetStringBuilder().ToString());
        }

        [Fact]
        public async Task ControlWithoutNameShouldNotBeRendered()
        {
            // Arrange
            var controlRendering = new ControlRendering();
            var page = new TestPage();
            var markup = "<asp:Literal Text=\"IsPostBack: False\"></asp:Literal>";
            var writer = new StringWriter(new StringBuilder());

            // Act
            await controlRendering.RenderAsync(page, markup, writer);

            // Assert
            Assert.Equal(string.Empty, writer.GetStringBuilder().ToString());
        }

        [Fact]
        public async Task NonExistControlShouldNotBeRendered()
        {
            // Arrange
            var controlRendering = new ControlRendering();
            var page = new TestPage();
            var markup = "<asp:Literal Name=\"litPostBack1\" Text=\"IsPostBack: False\"></asp:Literal>";
            var writer = new StringWriter(new StringBuilder());

            // Act
            await controlRendering.RenderAsync(page, markup, writer);

            // Assert
            Assert.Equal(string.Empty, writer.GetStringBuilder().ToString());
        }

        [Fact]
        public async Task RenderNestedControl()
        {
            // Arrange
            var controlRendering = new ControlRendering();
            var page = new TestPage();
            var markup = @"<asp:DropDownList Name=""ddlLanguages""><asp:ListItem Text=""C#""/><asp:ListItem Text=""F#""/><asp:ListItem Text=""VB""/></asp:DropDownList>";
            var writer = new StringWriter(new StringBuilder());

            // Act
            await controlRendering.RenderAsync(page, markup, writer);

            // Assert
            Assert.Equal(@"<select name=""ddlLanguages""><option name=""ddlLanguages"" value=""C#"">C#</option><option name=""ddlLanguages"" value=""F#"">F#</option><option name=""ddlLanguages"" value=""VB"">VB</option></select>", writer.GetStringBuilder().ToString());
        }

        private class TestPage : Page
        {
            public TestPage()
            {
                var literal = new Literal()
                {
                    Name = "litPostBack",
                    Text = "IsPostBack: False"
                };
                var dropDownList = new DropDownList
                {
                    Name = "ddlLanguages",
                    Items = new List<ListItem>
                    {
                        new ListItem("C#"),
                        new ListItem("F#"),
                        new ListItem("VB")
                    }
                };
                Controls.Add(literal);
                Controls.Add(dropDownList);
            }
        }
    }
}
