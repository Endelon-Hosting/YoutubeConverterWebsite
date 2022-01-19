using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoutubeConverterWebsite.Backend;

namespace YoutubeConverterWebsite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var x = ConverterHelper.GetUrl("https://www.youtube.com/watch?v=UtF6Jej8yb4").Result;
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
