using SolidariusAPI.Api.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidariusAPI.Api.TransferObjects
{
    public class ItemDto
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
