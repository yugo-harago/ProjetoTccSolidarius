using FluentValidation;
using SolidariusAPI.Api.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidariusAPI.Api.Validator
{
    public class DoadorValidador : AbstractValidator<DoadorDto>
    {
        public DoadorValidador()
        {

        }
    }
}
