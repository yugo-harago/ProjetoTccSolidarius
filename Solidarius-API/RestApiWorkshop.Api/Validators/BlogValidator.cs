using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using RestApiWorkshop.Api.Models;
using RestApiWorkshop.Api.TransferObjects;

namespace RestApiWorkshop.Api.Validators
{
    public class BlogValidator : AbstractValidator<BlogDto>
    {
        public BlogValidator()
        {
            RuleFor(a => a.Url).NotEmpty();
            RuleFor(a => a.Posts).Empty();
            RuleFor(a => a.Author).Null();
        }
    }
}