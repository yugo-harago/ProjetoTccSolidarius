using FluentValidation;
using SolidariusAPI.Api.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidariusAPI.Api.Validator
{
    public class ItemValidator : AbstractValidator<ItemDto>
    {
        public ItemValidator()
        {
            RuleFor(r => r.Categoria).NotEmpty();
            RuleFor(r => r.Descricao).NotEmpty();
            RuleFor(r => r.Titulo).NotEmpty();
        }
    }
}
