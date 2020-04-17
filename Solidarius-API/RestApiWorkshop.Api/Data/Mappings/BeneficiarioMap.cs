using FluentNHibernate.Mapping;
using SolidariusAPI.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidariusAPI.Api.Data.Mappings
{
    public class BeneficiarioMap : SubclassMap<Beneficiario>
    {
        // Subclass method: 
        // Table Per Type
        public BeneficiarioMap()
        {
            Table("Beneficiario");
            KeyColumn("BeneficiadoId");
            Not.LazyLoad();
            Map(x => x.Interno).Column("Interno");
            Map(x => x.Ra).Column("RA");
        }
    }
}
