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
    public class VentasController : ApiController
    {
        private readonly VentasService _ventasService;
        public VentasController(VentasService ventasService) 
        {
            _ventasService = ventasService;
        }

        [HttpGet]
        // GET: api/Ventas
        public IEnumerable<VentaModel> GetVentas()
        {
            return _ventasService.GetVentas();
        }

        [HttpGet]
        public IEnumerable<VentaModel> GetVentasPorFactura(int id)
        {
            return _ventasService.GetVentasPorFactura(id);
        }

        
        // GET: api/Ventas/5
        [ResponseType(typeof(Venta))]
        [HttpGet]
        public async Task<IHttpActionResult> GetVenta(int id)
        {
            Venta venta = await _ventasService.GetVenta(id);
            if (venta == null)
            {
                return NotFound();
            }

            return Ok(venta);
        }

        // PUT: api/Ventas/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public async Task<IHttpActionResult> PutVenta(int id, Venta venta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != venta.IdVenta)
            {
                return BadRequest();
            }
          
            try
            {
                await _ventasService.PutVenta(id, venta);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_ventasService.VentaExists(id))
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

        // POST: api/Ventas
        [ResponseType(typeof(Venta))]
        [HttpPost]
        public async Task<IHttpActionResult> PostVenta(Venta venta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _ventasService.PostVenta(venta);

            return Ok(venta);
        }

        // DELETE: api/Ventas/5
        [ResponseType(typeof(Venta))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteVenta(int id)
        {
            Venta venta = await _ventasService.GetVenta(id);
            if (venta == null)
            {
                return NotFound();
            }

            await _ventasService.DeleteVenta(id);

            return Ok(venta);
        }

    }
}