using FluentNHibernate.Mapping;
using SolidariusAPI.Api.Enum;
using SolidariusAPI.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidariusAPI.Api.Data.Mappings
{
    public class PedidoMap : ClassMap<Pedido>
    {
        public PedidoMap()
        {
            Table("Pedido");
            Not.LazyLoad();
            Id(x => x.Id).Column("PedidoId");
            Map(x => x.Quantidade).Column("Quantidade");
            Map(x => x.Estado).CustomType<Estado>().Column("Estado");
            Map(x => x.Comentario).Column("Comentario");
            Map(x => x.DataCriacao).Column("Data_Criacao");
            Map(x => x.DataModificacao).Column("Data_Modificacao");
            Map(x => x.Descricao).Column("Descricao");
            Map(x => x.Titulo).Column("Titulo");
            HasMany(x => x.Item).Table("Item").KeyColumn("PedidoId").ReadOnly();
            References(x => x.FeitoPor).Column("FeitoPor").Cascade.None();
            References(x => x.AceitoPor).Column("AceitoPor").Cascade.None();
        }
    }
}
