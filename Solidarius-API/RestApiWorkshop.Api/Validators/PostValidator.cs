using FluentValidation;
using RestApiWorkshop.Api.Models;
using RestApiWorkshop.Api.TransferObjects;

namespace RestApiWorkshop.Api.Validators
{
    public class PostValidator : AbstractValidator<PostDto>
    {
        public PostValidator()
        {
            RuleFor(a => a.Title).NotEmpty();
            RuleFor(a => a.Content).NotEmpty();
        }
    }
}