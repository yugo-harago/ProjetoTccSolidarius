using System;
using System.Collections.Generic;

namespace RestApiWorkshop.Client.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Foto { get; set; }
        public string Titulo { get; set; }
        public DateTime DataModificacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Descricao { get; set; }
        public Categoria Categoria { get; set; }
    }
}
