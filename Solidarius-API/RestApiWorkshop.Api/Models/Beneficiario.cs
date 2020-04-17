using SolidariusAPI.Api.Models;
using System.Collections.Generic;

namespace SolidariusAPI.Api.Models
{
    public class Beneficiario : Usuario
    {
        // public virtual int Id { get; set; }
        public virtual bool Interno { get; set; }
        public virtual string Ra { get; set; }
    }
}