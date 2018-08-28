using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Core.Entities;
using Blog.Infrastructure.Resource;

namespace Blog.Api.Extensions
{
    /// <summary>
    /// 配置映射关系
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //配置从Post映射到PostResource
            CreateMap<Post, PostResource>()
                //针对映射到的成员LastUpdate，MapFrom是来源至LastModified
                .ForMember(a => a.LastUpdate, opt => opt.MapFrom(a => a.LastModified));


            //配置从PostResource映射到Post 
            CreateMap<PostResource, Post>();
            //这样就配置完成双向映射
        }
    }
}
