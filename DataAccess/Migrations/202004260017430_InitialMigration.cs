namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        IdCliente = c.Int(nullable: false, identity: true),
                        Identificacion = c.String(),
                        Nombre = c.String(nullable: false, maxLength: 20),
                        Apellido = c.String(nullable: false, maxLength: 20),
                        FechaNacimineto = c.DateTime(nullable: false),
                        Telefono = c.String(nullable: false, maxLength: 20),
                        Direccion = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.IdCliente);
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        IdFactura = c.Int(nullable: false, identity: true),
                        IdCliente = c.Int(nullable: false),
                        Valor = c.Double(nullable: false),
                        ValorTotal = c.Double(nullable: false),
                        FechaFacturacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdFactura)
                .ForeignKey("dbo.Clientes", t => t.IdCliente, cascadeDelete: true)
                .Index(t => t.IdCliente);
            
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        IdVenta = c.Int(nullable: false, identity: true),
                        IdFactura = c.Int(nullable: false),
                        IdProducto = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        PrecioUnitario = c.Double(nullable: false),
                        PrecioTotal = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IdVenta)
                .ForeignKey("dbo.Facturas", t => t.IdFactura, cascadeDelete: true)
                .ForeignKey("dbo.Productos", t => t.IdProducto, cascadeDelete: true)
                .Index(t => t.IdFactura)
                .Index(t => t.IdProducto);
            
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        IdProducto = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 20),
                        Descripcion = c.String(maxLength: 100),
                        Precio = c.Double(nullable: false),
                        IVA = c.Double(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        PrecioInventario = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IdProducto);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ventas", "IdProducto", "dbo.Productos");
            DropForeignKey("dbo.Ventas", "IdFactura", "dbo.Facturas");
            DropForeignKey("dbo.Facturas", "IdCliente", "dbo.Clientes");
            DropIndex("dbo.Ventas", new[] { "IdProducto" });
            DropIndex("dbo.Ventas", new[] { "IdFactura" });
            DropIndex("dbo.Facturas", new[] { "IdCliente" });
            DropTable("dbo.Productos");
            DropTable("dbo.Ventas");
            DropTable("dbo.Facturas");
            DropTable("dbo.Clientes");
        }
    }
}
