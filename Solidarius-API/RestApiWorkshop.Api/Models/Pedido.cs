using SolidariusAPI.Api.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidariusAPI.Api.Models
{
    public class Pedido: IModel
    {
        public int Id { get; set; }

        public int Quantidade { get; set; }
        public Estado Estado { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Comentario { get; set; }
        public DateTime DataModificacao { get; set; }
        public string Descricao { get; set; }
        public string Titulo { get; set; }
        public IList<Item> Item { get; set; }
        public Usuario FeitoPor { get; set; }
        public Usuario AceitoPor { get; set; }
        public string Agradecimento { get; set; }
    }
}