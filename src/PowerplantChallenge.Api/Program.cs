using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace PowerplantChallenge.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseUrls("http://localhost:8888/")
                .Build()
                .Run();
        }
    }
}