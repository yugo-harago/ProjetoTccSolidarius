using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidariusAPI.Api.Models
{
    public class Usuario: IModel
    {
        public virtual int Id { get; set; }
        public virtual int Telefone { get; set; }
        public virtual string Documento { get; set; }
        public virtual string Email { get; set; }
        public virtual string Senha { get; set; }
        public virtual string Nome { get; set; }
        public virtual DateTime DataModificacao { get; set; }
        public virtual string FotoUsuario { get; set; }
        public virtual DateTime DataCriacao { get; set; }
    }
}
