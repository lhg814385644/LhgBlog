using System;
using System.Collections.Generic;
using System.Text;
using Blog.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Database
{
    /// <summary>
    /// 建立MyDbContext
    /// </summary>
   public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        public  DbSet<Post> Posts { get; set; }
        
    }
}
 