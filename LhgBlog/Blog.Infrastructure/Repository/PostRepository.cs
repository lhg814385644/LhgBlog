using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.Core.Entities;
using Blog.Core.interfaces;
using Blog.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly MyDbContext _myDbContext;

        public PostRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            return await _myDbContext.Posts.ToListAsync();
        }

        public void AddPost(Post input)
        {
            _myDbContext.Posts.Add(input);
        }
    }
}
