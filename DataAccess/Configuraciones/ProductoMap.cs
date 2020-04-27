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
    public class ProductoMap : EntityTypeConfiguration<Producto>
    {
        public ProductoMap() {

            ToTable("Productos");
            HasKey(k => k.IdProducto);
            Property(p => p.Nombre)
                .HasMaxLength(20)
                .IsRequired();
            Property(p => p.Descripcion)
                .HasMaxLength(100);

            Property(p => p.Precio)
                .IsRequired();

            Property(p => p.PrecioInventario)
                .IsRequired();
        }
    }
}
