using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WebFormsWebsite;
using Xunit;

namespace My.AspNetCore.WebForms.FunctionalTests
{
    public class WebFormsTest : IDisposable
    {
        private readonly TestServer _server;

        private static readonly string _applicationPath = Path.Combine("..", "..", "..", "..", "WebFormsWebsite");

        public WebFormsTest()
        {
            var builder = new WebHostBuilder()
                .UseContentRoot(_applicationPath)
                .UseStartup(typeof(RootedPagesStartup));

            _server = new TestServer(builder);

            Client = _server.CreateClient();
            Client.BaseAddress = new Uri("http://localhost");
        }

        public HttpClient Client { get; }

        [Fact]
        public async Task RequestInvalidPageReturnsNotFound()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/InvalidPage");

            // Act
            var response = await Client.SendAsync(request);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task RequestPageReturnsOK()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/");

            // Act
            var response = await Client.SendAsync(request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("Home", content);
        }

        public void Dispose()
        {
            Client.Dispose();
            _server.Dispose();
        }
    }
}
