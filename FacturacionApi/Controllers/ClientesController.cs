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
using DataAccess;
using DataAccess.Entidades;
using Modelos;
using Servicios;

namespace FacturacionApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ClientesController : ApiController
    {
        private readonly ClientesService _clientesService;

        public ClientesController(ClientesService clientesService) {

            _clientesService = clientesService;
        }

        // GET: api/Clientes
        public IEnumerable<ClienteModel> GetClientes()
        {
            return _clientesService.GetClientes();
        }

        // GET: api/Clientes/5
        [ResponseType(typeof(ClienteModel))]
        public async Task<IHttpActionResult> GetCliente(int id)
        {
            ClienteModel cliente = await _clientesService.GetCliente(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }
        public IEnumerable<ClienteModel>  GetClientesReporte(int edadCliente, DateTime fechaInicio, DateTime fechaFin)
        {
            return _clientesService.GetClientesReporte(edadCliente, fechaInicio, fechaFin);
        }

        // PUT: api/Clientes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCliente(int id, Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cliente.IdCliente)
            {
                return BadRequest();
            }

            try
            {
                await _clientesService.PutCliente(cliente);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_clientesService.ClienteExists(id))
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

        // POST: api/Clientes
        [ResponseType(typeof(ClienteModel))]
        public async Task<IHttpActionResult> PostCliente(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _clientesService.PostCliente(cliente);

            return Ok(cliente);
        }

        // DELETE: api/Clientes/5
        [ResponseType(typeof(ClienteModel))]
        public async Task<IHttpActionResult> DeleteCliente(int id)
        {
            ClienteModel cliente = await _clientesService.GetCliente(id);
            if (cliente == null)
            {
                return NotFound();
            }

            await _clientesService.DeleteCliente(id);

            return Ok(cliente);
        }

    }
}