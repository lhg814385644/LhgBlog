using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.Core.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;

namespace Blog.Infrastructure.Database
{
    /// <summary>
    /// 种子数据            
    /// </summary>
    public class MyContextSend
    {

        public static async Task SendAsync(MyDbContext context, ILoggerFactory loggerFactory, int retry = 0)
        {
            int _retry = retry;

            try
            {
                if (!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new List<Post>()
                        {
                            new Post()
                            {
                                Title = "Post Title1",
                                Body="Post Body1",
                                Author = "lhg",
                                LastModified=DateTime.Now
                            },
                            new Post()
                            {
                                Title = "Post Title1",
                                Body="Post Body1",
                                Author = "lhg",
                                LastModified=DateTime.Now
                            },
                            new Post()
                            {
                                Title = "Post Title1",
                                Body="Post Body1",
                                Author = "lhg",
                                LastModified=DateTime.Now
                            },
                            new Post()
                            {
                                Title = "Post Title1",
                                Body="Post Body1",
                                Author = "lhg",
                                LastModified=DateTime.Now
                            }
                        }
                    );

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                //出现错误小于10都继续操作
                //if (_retry < 100)
                //{
                //    _retry++;
                //    var logger = loggerFactory.CreateLogger<MyContextSend>();
                //    logger.LogError(e.Message);
                //    await SendAsync(context, loggerFactory, _retry);
                //}
            }

        }
    }
}
