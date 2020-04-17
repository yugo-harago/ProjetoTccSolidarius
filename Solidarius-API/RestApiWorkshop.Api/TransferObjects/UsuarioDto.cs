using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidariusAPI.Api.TransferObjects
{
    public class UsuarioDto
    {
        public int UsuarioId { get; set; }
        public int Telefone { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public DateTime DataModificacao { get; set; }
        public string FotoUsuario { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
