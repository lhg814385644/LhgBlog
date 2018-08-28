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
using Serilog;
using Serilog.Events;

namespace Blog.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {

            #region 配置Seailog

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug() //最小输出级别
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information) //重写，日志输出的最小级别如果是以Microsoft空间开头的，那么输出的最小级别就是Information
                .Enrich.FromLogContext()
                .WriteTo.Console()  //输出到控制台
                .WriteTo.File(Path.Combine("logs", @"log.txt"), rollingInterval: RollingInterval.Day) //输出到文件
                .CreateLogger();
            #endregion








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
                    logger.LogError(e, "Error occured on sending The Database    ");
                }

            }
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog();  //使用Serilog,并且会把之前默认的 Logger配置给覆盖掉，完全使用Serilog的配置
    }
}
