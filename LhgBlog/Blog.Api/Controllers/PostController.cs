using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Core.Entities;
using Blog.Core.interfaces;
using Blog.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace Blog.Api.Controllers
{
    [Route("api/posts")]
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;

        private readonly IUnitOfWork _unitOfWork;
        //private readonly MyDbContext _myDbContext;
        //public PostController(MyDbContext myDbContext)
        //{
        //    _myDbContext = myDbContext;
        //}
        //public async Task<IActionResult> GetPosts()
        //{
        //    var posts = await _myDbContext.Posts.ToListAsync();
        //    return Ok(posts);
        //}

        //采用仓储模式
        public PostController(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _postRepository.GetAllPosts();
            return Ok(posts);
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var input=new Post()
            {
                Author="lhg",
                Body="Body",
                Title="Title",
                LastModified=DateTime.Now
            };
            _postRepository.AddPost(input);
            await _unitOfWork.SaveAsync();
            return Ok("saveed");
        }


    }
}
