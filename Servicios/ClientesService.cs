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
    public class ClientesService
    {
        private readonly FacturacionContext _facturacionContext;

        public ClientesService(FacturacionContext facturacionContext) {

            _facturacionContext = facturacionContext;
        }

        public IList<ClienteModel> GetClientes()
        {
            return _facturacionContext.Clientes.ProjectToList<ClienteModel>();
        }

        public IEnumerable<ClienteModel> GetClientesReporte(int edadCliente, DateTime fechaInicio, DateTime fechaFin)
        {
            var res = _facturacionContext.Clientes.ToList()
                .Where(c => ObtenerEdad(c.FechaNacimineto) == edadCliente && c.Facturas.Any(f => f.FechaFacturacion >= fechaInicio && f.FechaFacturacion <= fechaFin));

            return Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteModel>>(res);
        }

        public async Task<ClienteModel> GetCliente(int id)
        {
            Cliente cliente = await _facturacionContext.Clientes.FindAsync(id);
            if (cliente == null)
            {
                throw new Exception("");
            }

            return Mapper.Map<Cliente, ClienteModel>(cliente);
        }


        public async Task<ClienteModel> GetUltimaFechaCompraCliente(int id)
        {
            Cliente cliente = await _facturacionContext.Clientes.FindAsync(id);
            if (cliente == null)
            {
                throw new Exception("");
            }

            var clienteModel = Mapper.Map<Cliente, ClienteModel>(cliente);

            clienteModel.UltimaFechaCompra = cliente.Facturas.Max(f => f.FechaFacturacion);
            clienteModel.ProximaFechaCompra = CalcularProximaFechaCompra(id, cliente.Facturas);

            return clienteModel;
        }


        public async Task<ClienteModel> PutCliente(Cliente cliente)
        {
           
            _facturacionContext.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _facturacionContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;          
            }

            return Mapper.Map<Cliente, ClienteModel>(cliente); 
        }


        public async Task<ClienteModel> PostCliente(Cliente cliente)
        {
        
            _facturacionContext.Clientes.Add(cliente);
            await _facturacionContext.SaveChangesAsync();

            return Mapper.Map<Cliente, ClienteModel>(cliente);
        }


        public async Task<bool> DeleteCliente(int id)
        {
            Cliente cliente = await _facturacionContext.Clientes.FindAsync(id);
            if (cliente == null)
            {
                throw new Exception("");
            }

            _facturacionContext.Clientes.Remove(cliente);
            await _facturacionContext.SaveChangesAsync();

            return true;
        }

        public bool ClienteExists(int id)
        {
            return _facturacionContext.Clientes.Count(e => e.IdCliente == id) > 0;
        }


        private DateTime CalcularProximaFechaCompra(int idCliente, IList<Factura> facturas) 
        {
            
            return new DateTime();
        }

        public DateTime CalcularProximaFechaCompraTest()
        {
          
            return new DateTime();
        }

        private int ObtenerEdad(DateTime fechaNacimineto) {

            var hoy = DateTime.Today;
            var edad = hoy.Year - fechaNacimineto.Year;
            if (fechaNacimineto.Date > hoy.AddYears(-edad)) edad--;

            return edad;
        }

    }
}
