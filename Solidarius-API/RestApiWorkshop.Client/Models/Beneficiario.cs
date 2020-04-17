using System.Collections.Generic;

namespace RestApiWorkshop.Client.Models
{
    public class Beneficiario : Usuario
    {
        public int Id { get; set; }

        public bool Interno { get; set; }

        public string Ra { get; set; }
    }
}