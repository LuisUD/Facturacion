using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataAccess;
using DataAccess.Entidades;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ProductosService
    {
        private readonly FacturacionContext _facturacionContext;

        public ProductosService(FacturacionContext facturacionContext)
        {
            _facturacionContext = facturacionContext;
        }

        public IList<ProductoModel> GetProductos()
        {
            return _facturacionContext.Productos.ProjectToList<ProductoModel>();
        }

        public IList<ProductoModel> GetProductosPorCantidad(int cantidad)
        {
            return _facturacionContext.Productos.Where(p => p.Cantidad == cantidad).ProjectToList<ProductoModel>();
        }

        public async Task<ProductoModel> GetProducto(int id)
        {
            Producto Producto = await _facturacionContext.Productos.FindAsync(id);
            if (Producto == null)
            {
                throw new Exception("");
            }

            return Mapper.Map<Producto, ProductoModel>(Producto);
        }


        public IEnumerable<ProductoModel> GetTotalVendidoProductoPorAnio(int anio = 0)
        {
            if (anio == 0) anio = DateTime.Now.Year;

            var resultado = (from p in _facturacionContext.Productos
                             let ventas = p.Ventas.Where(v => v.Factura.FechaFacturacion.Year == anio).ToList()
                             select new ProductoModel{ 
                     
                     Cantidad = p.Cantidad,
                     Descripcion = p.Descripcion,
                     ValorTotal = ventas.Count() > 0 ? ventas.Sum(v => v.PrecioTotal) : 0,
                     Nombre = p.Nombre,
                     IdProducto = p.IdProducto
                     }).ToList();

            return resultado;
        }


        public async Task<ProductoModel> PutProducto(int id, Producto Producto)
        {

            _facturacionContext.Entry(Producto).State = EntityState.Modified;

            try
            {
                await _facturacionContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
                {
                    throw new Exception("");
                }
                else
                {
                    throw;
                }
            }

            return Mapper.Map<Producto, ProductoModel>(Producto); 
        }


        public async Task<ProductoModel> PostProducto(Producto Producto)
        {

            _facturacionContext.Productos.Add(Producto);
            await _facturacionContext.SaveChangesAsync();

            return Mapper.Map<Producto, ProductoModel>(Producto);
        }


        public async Task<bool> DeleteProducto(int id)
        {
            Producto Producto = await _facturacionContext.Productos.FindAsync(id);
            if (Producto == null)
            {
                throw new Exception("");
            }

            _facturacionContext.Productos.Remove(Producto);
            await _facturacionContext.SaveChangesAsync();

            return true;
        }

        public bool ProductoExists(int id)
        {
            return _facturacionContext.Productos.Count(e => e.IdProducto == id) > 0;
        }
    }
}
