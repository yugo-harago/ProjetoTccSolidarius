using FluentNHibernate.Mapping;
using SolidariusAPI.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidariusAPI.Api.Data.Mappings
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Table("Usuario");

            Id(x => x.Id).Column("UsuarioId");
            Map(x => x.Nome).Column("Nome");
            Map(x => x.Senha).Column("Senha");
            Map(x => x.Telefone).Column("Telefone");
            Map(x => x.FotoUsuario).Column("Foto_usuario");
            Map(x => x.DataCriacao).Column("Data_Criacao");
            Map(x => x.DataModificacao).Column("Data_Modificacao");
            Map(x => x.Email).Column("Email");
            Map(x => x.Documento).Column("Documento");

            //DiscriminateSubClassesOnColumn("UsuarioId");
        }
    }
}
