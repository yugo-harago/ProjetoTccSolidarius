using System.Collections.Generic;

namespace RestApiWorkshop.Client.Models
{
    public class Beneficiario : Usuario
    {

        public bool Interno { get; set; }

        public string Ra { get; set; }
    }
}