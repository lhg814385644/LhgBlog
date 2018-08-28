using System;
using System.Collections.Generic;
using System.Text;
using Blog.Core.Entities;

namespace Blog.Infrastructure.Resource
{
    /// <summary>
    /// post DTO
    /// </summary>
    public class PostResource : Entity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
        public DateTime LastUpdate { get; set; }

    }
}
