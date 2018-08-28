using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Blog.Infrastructure.Resource
{
    /// <summary>
    ///  PostResource验证规则
    /// </summary>
    public class PostResourceValidator : AbstractValidator<PostResource>
    {
        public PostResourceValidator()
        {
            RuleFor(a => a.Author)
                .NotNull()
                .WithName("作者")
                .WithMessage("{ProPertyName}是必填项")
                .MaximumLength(50)
                .WithMessage("{ProPertyName}最大长度是{MaxLength}");
        }
    }
}
