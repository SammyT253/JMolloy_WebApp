using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace JMolloy
{
    public class Program
    {
        //attempt at auto-selecting the right code based on environment

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        //Development Code/Windows deployment
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        //Production Code
        /*  public static IHostBuilder CreateHostBuilder(string[] args) =>
              Host.CreateDefaultBuilder(args)
                  .ConfigureWebHostDefaults(webBuilder =>
                  {
                      webBuilder.UseKestrel()
                          .UseContentRoot(Directory.GetCurrentDirectory())
                          .UseUrls("http://*:5000")
                          .UseStartup<Startup>();
                  });*/
    }
}
