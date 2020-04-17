using FluentValidation;
using SolidariusAPI.Api.Models;
using SolidariusAPI.Api.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidariusAPI.Api.Validator
{
    public class BeneficiarioValidator : AbstractValidator<BeneficiarioDto>
    {
        public BeneficiarioValidator()
        {
            RuleFor(r => r.Interno).NotEmpty();
            RuleFor(r => r.Nome).NotEmpty();
            RuleFor(r => r.Ra).NotEmpty();
            RuleFor(r => r.Senha).NotEmpty();
            RuleFor(r => r.Telefone).NotEmpty();
        }
    }
}
