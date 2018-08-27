using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Core.interfaces;
using Blog.Infrastructure.Database;
using Blog.Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Api
{
    public class Startup
    {
        //服务注册
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //配置数据库服务
            services.AddDbContext<MyDbContext>(options =>
            {
                options.UseMySql("Server=107.173.181.31;Port=3306;Database=lhgBlogDB; User=root;Password=lhg1995;");
            });
            
            //注册Https Service
            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect; //状态码
                options.HttpsPort = 5001; //使用的端口
            });

            //注册hSTS（建议生产环境使用）
            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(60);
                options.ExcludedHosts.Add("example.com");
                options.ExcludedHosts.Add("www.example.com");
            });

            //注册接口服务
            services.AddScoped<IUnitOfWork, UnitOfWork>();  
            services.AddScoped<IPostRepository, PostRepository>();
            

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app">用于构建中间件管道</param>
        /// <param name="env">环境变量</param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //使用Hsts
            app.UseHsts();
            //使用Https 重定向中间件（注意，这个使用中间件的顺序很重要，必须要在UseMvc之前）
            app.UseHttpsRedirection();

            //配置使用MVC中间件（默认的路由，特性方式）
            app.UseMvc();
        }
    }
}
