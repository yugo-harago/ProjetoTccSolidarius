using FluentValidation;
using SolidariusAPI.Api.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidariusAPI.Api.Validator
{
    public class MediadorValidator : AbstractValidator<MediadorDto>
    {
        public MediadorValidator()
        {
            RuleFor(r => r.ra).NotEmpty();
        }
    }
}
