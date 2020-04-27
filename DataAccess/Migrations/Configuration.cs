namespace DataAccess.Migrations
{
    using DataAccess.Entidades;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.FacturacionContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataAccess.FacturacionContext context)
        {

            IList<Cliente> baseClientes = new List<Cliente>();

            baseClientes.Add(new Cliente() { Identificacion = "6546516584", Nombre = "Luis", Apellido = "Meneses", Direccion = "Cll 46 c c sur # 99", FechaNacimineto = new DateTime(1992, 12, 1), Telefono = "999999" });
            baseClientes.Add(new Cliente() { Identificacion = "4536667777", Nombre = "Pedro", Apellido = "Meneses", Direccion = "Cll 46 c c sur # 99", FechaNacimineto = new DateTime(1962, 12, 1), Telefono = "999999" });
            baseClientes.Add(new Cliente() { Identificacion = "2342342", Nombre = "Juan", Apellido = "Meneses", Direccion = "Cll 46 c c sur # 99", FechaNacimineto = new DateTime(1972, 12, 1), Telefono = "999999" });
            baseClientes.Add(new Cliente() { Identificacion = "23422222", Nombre = "Pablo", Apellido = "Meneses", Direccion = "Cll 46 c c sur # 99", FechaNacimineto = new DateTime(1982, 12, 1), Telefono = "999999" });
            baseClientes.Add(new Cliente() { Identificacion = "34346546", Nombre = "Diego", Apellido = "Meneses", Direccion = "Cll 46 c c sur # 99", FechaNacimineto = new DateTime(1999, 12, 1), Telefono = "999999" });
            baseClientes.Add(new Cliente() { Identificacion = "6756434456", Nombre = "Carlos", Apellido = "Meneses", Direccion = "Cll 46 c c sur # 99", FechaNacimineto = new DateTime(2005, 12, 1), Telefono = "999999" });
            baseClientes.Add(new Cliente() { Identificacion = "9789787", Nombre = "Andres", Apellido = "Meneses", Direccion = "Cll 46 c c sur # 99", FechaNacimineto = new DateTime(2000, 12, 1), Telefono = "999999" });
            baseClientes.Add(new Cliente() { Identificacion = "121265687", Nombre = "Leonardo", Apellido = "Meneses", Direccion = "Cll 46 c c sur # 99", FechaNacimineto = new DateTime(1886, 12, 1), Telefono = "999999" });
            baseClientes.Add(new Cliente() { Identificacion = "56878333455", Nombre = "Jairo", Apellido = "Meneses", Direccion = "Cll 46 c c sur # 99", FechaNacimineto = new DateTime(1992, 12, 1), Telefono = "999999" });
            baseClientes.Add(new Cliente() { Identificacion = "227063453", Nombre = "Alex", Apellido = "Meneses", Direccion = "Cll 46 c c sur # 99", FechaNacimineto = new DateTime(1992, 12, 1), Telefono = "999999" });

            context.Clientes.AddRange(baseClientes);

            IList<Producto> baseProductos = new List<Producto>();

            baseProductos.Add(new Producto { Nombre = "Papa", Cantidad = 1000, Descripcion = "papa por unidad", Precio = 500, IVA = 0.10, PrecioInventario = 500000 });
            baseProductos.Add(new Producto { Nombre = "Pollo", Cantidad = 1000, Descripcion = "papa por unidad", Precio = 500, IVA = 0.10, PrecioInventario = 500000 });
            baseProductos.Add(new Producto { Nombre = "Carne", Cantidad = 1000, Descripcion = "papa por unidad", Precio = 500, IVA = 0.10, PrecioInventario = 500000 });
            baseProductos.Add(new Producto { Nombre = "Jamon", Cantidad = 1000, Descripcion = "papa por unidad", Precio = 500, IVA = 0.10, PrecioInventario = 500000 });
            baseProductos.Add(new Producto { Nombre = "Arroz", Cantidad = 1000, Descripcion = "papa por unidad", Precio = 500, IVA = 0.10, PrecioInventario = 500000 });

            context.Productos.AddRange(baseProductos);

        }
    }
}
