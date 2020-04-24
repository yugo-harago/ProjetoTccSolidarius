using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidariusAPI.Api.TransferObjects
{
    public class NotificacaoDto : IDto
    {
        public virtual int Id { get; set; }
        public virtual UsuarioDto Para { get; set; }
        public virtual UsuarioDto Por { get; set; }
        public virtual string Descricao { get; set; }
        public virtual bool Visto { get; set; }
        public virtual bool Confirmado { get; set; }
        public virtual PedidoDto Pedido { get; set; }
    }
}
