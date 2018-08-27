using System;
using System.Collections.Generic;
using System.Text;
using Blog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Database.EntityConfigrations
{
    /// <summary>
    /// 配置Entity约束
    /// </summary>
    /// <remarks>todo:注意每次修改完约束之后都需要Add-Migration,Update-Database  将约束应用到数据库</remarks>
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(a => a.Author).IsRequired().HasMaxLength(50);
            //builder.Property(a=>a.Body).HasMaxLength()
            builder.Property(a => a.Title).HasMaxLength(200);
        }
    }
}
