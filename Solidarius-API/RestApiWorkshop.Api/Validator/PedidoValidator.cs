using FluentValidation;
using SolidariusAPI.Api.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidariusAPI.Api.Validator
{
    public class PedidoValidator : AbstractValidator<PedidoDto>
    {
        public PedidoValidator()
        {
            RuleFor(r => r.Estado).NotEmpty();
            RuleFor(r => r.Quantidade).NotEmpty();
        }
    }
}
