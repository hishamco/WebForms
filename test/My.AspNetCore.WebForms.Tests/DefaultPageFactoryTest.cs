using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;
using My.AspNetCore.WebForms.Infrastructure;
using Moq;
using Xunit;

namespace My.AspNetCore.WebForms.Tests
{
    public class DefaultPageFactoryTest
    {
        [Fact]
        public void CreateInvalidPageReturnNull()
        {
            // Arrange
            var webFormsOptions = new Mock<IOptions<WebFormsOptions>>();
            webFormsOptions.Setup(o => o.Value).Returns(new WebFormsOptions());
            var hostingEnv = new Mock<IHostingEnvironment>();
            hostingEnv.Setup(h => h.ApplicationName)
                .Returns(typeof(DefaultPageFactory).GetTypeInfo().Assembly.GetName().Name);
            var pageFactory = new DefaultPageFactory(webFormsOptions.Object, hostingEnv.Object);

            // Act
            var page = pageFactory.CreatePage("InvalidPage");

            // Assert
            Assert.Equal(null, page);
        }
    }
}
