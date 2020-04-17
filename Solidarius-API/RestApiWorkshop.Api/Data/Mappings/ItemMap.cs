using FluentNHibernate.Mapping;
using SolidariusAPI.Api.Enum;
using SolidariusAPI.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidariusAPI.Api.Data.Mappings
{
    public class ItemMap : ClassMap<Item>
    {
        public ItemMap()
        {
            Table("Item");
            Id(x => x.Id).Column("ItemId");
            Map(x => x.Foto).Column("Foto");
            Map(x => x.Titulo).Column("Titulo");
            Map(x => x.DataModificacao).Column("Data_Modificacao");
            Map(x => x.DataCriacao).Column("Data_Criacao");
            Map(x => x.Descricao).Column("Descricao");
            Map(x => x.Categoria).Column("CategoriaId").CustomType<Categoria>();
        }
    }
}
