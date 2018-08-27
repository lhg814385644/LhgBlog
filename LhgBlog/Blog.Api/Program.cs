using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Blog.Infrastructure.Database;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Blog.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            //创建一个作用域
            using (var scope = host.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                //从容器中获取loggerFactory
                var loggerFactory = service.GetRequiredService<ILoggerFactory>();
                try
                {
                    var mycontext = service.GetRequiredService<MyDbContext>();
                    MyContextSend.SendAsync(mycontext, loggerFactory).Wait();
                }
                catch (Exception e)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(e,"Error occured on sending The Database    ");
                }

            }


            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
