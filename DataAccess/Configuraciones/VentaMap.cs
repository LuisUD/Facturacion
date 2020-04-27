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
    public class VentaMap : EntityTypeConfiguration<Venta>
    {
        public VentaMap() {

            ToTable("Ventas");
            HasKey(k => k.IdVenta);
            Property(p => p.Cantidad)
                .IsRequired();
            Property(p => p.PrecioTotal)
                .IsRequired();
            Property(p => p.PrecioUnitario)
                .IsRequired();

        }
    }
}
