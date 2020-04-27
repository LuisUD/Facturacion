using DataAccess.Configuraciones;
using DataAccess.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FacturacionContext : DbContext
    {
        public FacturacionContext() : base("name=Facturacion")
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Factura> Facturas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClienteMap());
            modelBuilder.Configurations.Add(new FacturaMap());
            modelBuilder.Configurations.Add(new ProductoMap());
            modelBuilder.Configurations.Add(new VentaMap());
        }
    }

}
