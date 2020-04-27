using DataAccess.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuraciones
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap() {

            ToTable("Clientes");
            HasKey(k => k.IdCliente);
            Property(p => p.Nombre)
                .HasMaxLength(20)
                .IsRequired();
            Property(p => p.Apellido)
                .HasMaxLength(20)
                .IsRequired();
            Property(p => p.Direccion)
                .HasMaxLength(20)
                .IsRequired();
            Property(p => p.Telefono)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
