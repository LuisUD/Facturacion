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
    public class FacturaMap : EntityTypeConfiguration<Factura>
    {
        public FacturaMap() {

            ToTable("Facturas");
            HasKey(k => k.IdFactura);
            Property(p => p.Valor)
                .IsRequired();
            Property(p => p.ValorTotal)
                .IsRequired();
            Property(p => p.FechaFacturacion)
                .IsRequired();
        }
    }
}
