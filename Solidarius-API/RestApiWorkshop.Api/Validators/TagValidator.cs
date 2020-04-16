using FluentValidation;
using RestApiWorkshop.Api.Models;
using RestApiWorkshop.Api.TransferObjects;

namespace RestApiWorkshop.Api.Validators
{
    public class TagValidator : AbstractValidator<TagDto>
    {
        public TagValidator()
        {
            RuleFor(a => a.Value).NotEmpty();
        }
    }
}