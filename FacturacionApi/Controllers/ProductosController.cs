using DataAccess.Entidades;
using Modelos;
using Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;


namespace FacturacionApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductosController : ApiController
    {
        private readonly ProductosService _productosService;
        public ProductosController(ProductosService productosService) 
        {
            _productosService = productosService;
        }

        // GET: api/Productoes
        [HttpGet]
        public IEnumerable<ProductoModel> GetProductos()
        {
            return _productosService.GetProductos();
        }

        [HttpGet]
        public IEnumerable<ProductoModel> ProductosCantidad(int cantidad)
        {
            return _productosService.GetProductosPorCantidad(cantidad);
        }

        [HttpGet]
        public IEnumerable<ProductoModel> ProductosPorAnio(int anio)
        {
            return _productosService.GetTotalVendidoProductoPorAnio(anio);
        }

        // GET: api/Productoes/5
        [ResponseType(typeof(ProductoModel))]
        [HttpGet]
        public async Task<IHttpActionResult> GetProducto(int id)
        {
            ProductoModel producto = await _productosService.GetProducto(id);
            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        // PUT: api/Productoes/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public async Task<IHttpActionResult> PutProducto(int id, Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != producto.IdProducto)
            {
                return BadRequest();
            }

            try
            {
                await _productosService.PutProducto(id, producto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_productosService.ProductoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/Productoes
        [ResponseType(typeof(ProductoModel))]
        [HttpPost]
        public async Task<IHttpActionResult> PostProducto(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _productosService.PostProducto(producto);

            return Ok(producto);
        }

        // DELETE: api/Productoes/5
        [ResponseType(typeof(ProductoModel))]
        public async Task<IHttpActionResult> DeleteProducto(int id)
        {
            ProductoModel producto = await _productosService.GetProducto(id);
            if (producto == null)
            {
                return NotFound();
            }

            await _productosService.DeleteProducto(id);

            return Ok(producto);
        }

    }
}