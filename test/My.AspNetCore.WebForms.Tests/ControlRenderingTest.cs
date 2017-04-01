using My.AspNetCore.WebForms.Controls;
using My.AspNetCore.WebForms.Rendering;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace My.AspNetCore.WebForms.Tests
{
    public class ControlRenderingTest
    {
        [Fact]
        public async Task RenderControlInNestedmarkup()
        {
            // Arrange
            var controlRendering = new ControlRendering();
            var page = new TestPage();
            var markup = "<span class=\"label label-info\"><asp:Literal Name=\"litPostBack\" Text=\"IsPostBack: False\"></asp:Literal></span>";
            var writer = new StringWriter(new StringBuilder());
            
            // Act
            await controlRendering.RenderAsync(page, markup, writer);

            // Assert
            Assert.Equal("<span class=\"label label-info\">IsPostBack: False</span>",
                writer.GetStringBuilder().ToString());
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
                Controls.Add(literal);
            }
        }
    }
}
