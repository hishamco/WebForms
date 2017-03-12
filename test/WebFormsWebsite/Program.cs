using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace WebFormsWebsite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup("WebFormsWebsite")
                .Build();

            host.Run();
        }
    }
}
