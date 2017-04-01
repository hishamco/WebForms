using My.AspNetCore.WebForms.Infrastructure;
using Xunit;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace My.AspNetCore.WebForms.Tests
{
    public class DefaultPageLoaderTest
    {
        [Theory]
        [InlineData("TestPage")]
        [InlineData("testPage")]
        [InlineData("tEStPage")]
        public void LoadPageShouldIgnoreRelativePathCasing(string path)
        {
            // Arrange
            var webFormsOptions = Options.Create(new WebFormsOptions());
            var hostingEnvironment = new HostingEnvironment()
            {
                ApplicationName = "My.AspNetCore.WebForms.Tests"
            };
            var pageLoader = new DefaultPageLoader(webFormsOptions, hostingEnvironment);

            // Act
            var page = pageLoader.Load(path);

            // Assert
            Assert.NotNull(page);
        }

        [Fact]
        public void NestedPageShouldBeLoaded()
        {
            // Arrange
            var webFormsOptions = Options.Create(new WebFormsOptions());
            var hostingEnvironment = new HostingEnvironment()
            {
                ApplicationName = "My.AspNetCore.WebForms.Tests"
            };
            var pageLoader = new DefaultPageLoader(webFormsOptions, hostingEnvironment);

            // Act
            var page = pageLoader.Load("Admin/LoginPage");

            // Assert
            Assert.NotNull(page);
        }
    }
}
