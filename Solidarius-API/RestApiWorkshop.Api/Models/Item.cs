using SolidariusAPI.Api.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidariusAPI.Api.Models
{
    public class Item: IModel
    {
        public virtual int Id { get; set; }
        public virtual string Foto { get; set; }
        public virtual string Titulo { get; set; }
        public virtual DateTime DataModificacao { get; set; }
        public virtual DateTime DataCriacao { get; set; }
        public virtual string Descricao { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}
