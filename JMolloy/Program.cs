using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace JMolloy
{
    public class Program
    {
        //update to auto-selecting the right code based on environment

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        //Development/windows prod config
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        //Configuration for Kestrel with apache/nginx reverse proxy on Linux

        /*   public static IHostBuilder CreateHostBuilder(string[] args) =>
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
