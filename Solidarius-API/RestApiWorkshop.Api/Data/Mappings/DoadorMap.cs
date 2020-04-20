using FluentNHibernate.Mapping;
using SolidariusAPI.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidariusAPI.Api.Data.Mappings
{
    public class DoadorMap : SubclassMap<Doador>
    {
        public DoadorMap()
        {
            Table("Doador");
            KeyColumn("UsuarioId");
            Not.LazyLoad();
        }
    }
}
