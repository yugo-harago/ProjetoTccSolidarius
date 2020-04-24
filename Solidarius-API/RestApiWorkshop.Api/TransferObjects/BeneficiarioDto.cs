using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidariusAPI.Api.TransferObjects
{
    public class BeneficiarioDto : UsuarioDto
    {

        public bool Interno { get; set; }

        public int Ra { get; set; }
    }
}
