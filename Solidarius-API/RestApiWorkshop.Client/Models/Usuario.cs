using System;
using System.Collections.Generic;

namespace RestApiWorkshop.Client.Models
{
    public class Usuario
    {
        public int UserId { get; set; }
        public int Telefone { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public DateTime Data_Modificacao { get; set; }
        public string Foto_usuario { get; set; }
        public DateTime Data_Criacao { get; set; }
    }
}
