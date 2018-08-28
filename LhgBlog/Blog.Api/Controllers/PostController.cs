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
using Microsoft.Extensions.Logging;

namespace Blog.Api.Controllers
{
    [Route("api/posts")]
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;

        private readonly IUnitOfWork _unitOfWork;
        //todo: ILogger<TCategoryName>  TCategoryName:表示是在哪个类中调用
        //private readonly ILogger<PostController> _logger;
        private readonly ILogger _logger;

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
        public PostController(IPostRepository postRepository,
            IUnitOfWork unitOfWork,
            //ILogger<PostController> logger
            ILoggerFactory loggerFactory  //用loggerFactory方式创建Logger
            )
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
            //_logger = logger;
            _logger = loggerFactory.CreateLogger("Blog.Api.Controllers.PostController"); //这里创建Logge要求传全命名空间 
        }
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _postRepository.GetAllPosts();
             //这样是输出到控制台
            // _logger.LogInformation("all post");
            //_logger.CreateLogger("")
            return Ok(posts);
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var input = new Post()
            {
                Author = "lhg",
                Body = "Body",
                Title = "Title",
                LastModified = DateTime.Now
            };
            _postRepository.AddPost(input);
            await _unitOfWork.SaveAsync();
            return Ok("saveed");
        }


    }
}
