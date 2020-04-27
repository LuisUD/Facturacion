using DataAccess;
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
    public class FacturasController : ApiController
    {
        private readonly FacturasService _facturasService;
        public FacturasController(FacturasService facturasService) 
        {
            _facturasService = facturasService;
        }

        // GET: api/Facturas
        [HttpGet]
        public IEnumerable<FacturaModel> GetFacturas()
        {
            return _facturasService.GetFacturas();
        }

        // GET: api/Facturas/5
        [ResponseType(typeof(FacturaModel))]
        [HttpGet]
        public async Task<IHttpActionResult> GetFactura(int id)
        {
            FacturaModel factura = await _facturasService.GetFactura(id);
            if (factura == null)
            {
                return NotFound();
            }

            return Ok(factura);
        }

        // PUT: api/Facturas/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public async Task<IHttpActionResult> PutFactura(int id, Factura factura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != factura.IdFactura)
            {
                return BadRequest();
            }

            try
            {
                await _facturasService.PutFactura(id, factura);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_facturasService.FacturaExists(id))
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

        // POST: api/Facturas
        [ResponseType(typeof(FacturaModel))]
        [HttpPost]
        public async Task<IHttpActionResult> PostFactura(InputCrearFactura input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _facturasService.PostFactura(input);

            return Ok(input.Factura);
        }

        // DELETE: api/Facturas/5
        [ResponseType(typeof(FacturaModel))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteFactura(int id)
        {
            FacturaModel factura = await _facturasService.GetFactura(id);
            if (factura == null)
            {
                return NotFound();
            }

            await _facturasService.DeleteFactura(id);

            return Ok(factura);
        }

    }
}