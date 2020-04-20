using FluentNHibernate.Mapping;
using SolidariusAPI.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidariusAPI.Api.Data.Mappings
{
    public class MediadorMap : SubclassMap<Mediador>
    {
        public MediadorMap()
        {
            Table("Mediador");
            KeyColumn("MediadorId");
            Not.LazyLoad();
            Map(x => x.Ra).Column("RA");
        }
    }
}
