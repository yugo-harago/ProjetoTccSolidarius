using FluentNHibernate.Mapping;
using SolidariusAPI.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidariusAPI.Api.Data.Mappings
{
    public class NotificacaoMap : ClassMap<Notificacao>
    {
        public NotificacaoMap()
        {
            Table("Notificacao");
            Not.LazyLoad();
            Id(x => x.Id).Column("NotificacaoId");
            References(x => x.Para).Column("Para");
            References(x => x.Por).Column("Por");
            Map(x => x.Visto).Column("Visto");
            Map(x => x.Confirmado).Column("Confirmado");
            Map(x => x.Descricao).Column("Descricao");
            References(x => x.Pedido).Column("Pedido");
        }
    }
}
