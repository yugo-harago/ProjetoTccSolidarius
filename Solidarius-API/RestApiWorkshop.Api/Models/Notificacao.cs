using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidariusAPI.Api.Models
{
    public class Notificacao: IModel
    {
        public virtual int Id { get; set; }
        public virtual Usuario Para { get; set; }
        public virtual Usuario Por { get; set; }
        public virtual string Descricao { get; set; }
        public virtual bool Visto { get; set; }
        public virtual bool Confirmado { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}
