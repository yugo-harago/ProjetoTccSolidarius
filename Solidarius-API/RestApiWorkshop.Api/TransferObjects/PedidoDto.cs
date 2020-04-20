using SolidariusAPI.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidariusAPI.Api.TransferObjects
{
    public class PedidoDto : IDto
    {
        public int Id { get; set; }

        public int Quantidade { get; set; }
        public string Estado { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Comentario { get; set; }
        public DateTime DataModificacao { get; set; }
        public string Descricao { get; set; }
        public IList<Item> Item { get; set; } = new List<Item>();
    }
}
