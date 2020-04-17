using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidariusAPI.Api.TransferObjects
{
    public class BeneficiarioDto : UsuarioDto
    {
        public int Id { get; set; }

        public bool Interno { get; set; }

        public string Ra { get; set; }
    }
}
