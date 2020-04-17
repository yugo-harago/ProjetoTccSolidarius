using System;
using System.Collections.Generic;

namespace RestApiWorkshop.Client.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        public int Quantidade { get; set; }
        public string Estado { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Comentario { get; set; }
        public DateTime DataModificacao { get; set; }
        public string Descricao { get; set; }
    }
}