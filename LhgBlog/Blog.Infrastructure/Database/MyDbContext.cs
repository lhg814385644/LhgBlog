using Blog.Core.Entities;
using Blog.Infrastructure.Database.EntityConfigrations;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //应用Entity约束
            modelBuilder.ApplyConfiguration(new PostConfig());

            base.OnModelCreating(modelBuilder);

        }

        public  DbSet<Post> Posts { get; set; }
        
    }
}
 