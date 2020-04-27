using AutoMapper;
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
    public class FacturasService
    {
        private readonly FacturacionContext _facturacionContext;

        public FacturasService(FacturacionContext facturacionContext)
        {

            _facturacionContext = facturacionContext;
        }


        public IList<FacturaModel> GetFacturas()
        {
            return _facturacionContext.Facturas.ProjectToList<FacturaModel>();
        }


        public async Task<FacturaModel> GetFactura(int id)
        {
            Factura Factura = await _facturacionContext.Facturas.FindAsync(id);
            if (Factura == null)
            {
                throw new Exception("");
            }

            return Mapper.Map<Factura, FacturaModel>(Factura);
        }


        public async Task<FacturaModel> PutFactura(int id, Factura Factura)
        {

            _facturacionContext.Entry(Factura).State = EntityState.Modified;

            try
            {
                await _facturacionContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaExists(id))
                {
                    throw new Exception("");
                }
                else
                {
                    throw;
                }
            }

            return Mapper.Map<Factura, FacturaModel>(Factura); 
        }


        public async Task<FacturaModel> PostFactura(InputCrearFactura input)
        {
            var facturaBd = Mapper.Map<FacturaModel ,Factura>(input.Factura);
            var ventasBd = Mapper.Map<IList<VentaModel>, IList<Venta>>(input.Ventas);

            var cliente = _facturacionContext.Clientes.First(c => c.IdCliente == input.Factura.IdCliente);

            facturaBd.Cliente = cliente;
            facturaBd.Ventas = ventasBd.ToList();

            try
            {
                _facturacionContext.Facturas.Add(facturaBd);
                await _facturacionContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var ff = ex;
                throw;
            }
             

            return input.Factura;
        }


        public async Task<bool> DeleteFactura(int id)
        {
            Factura Factura = await _facturacionContext.Facturas.FindAsync(id);
            if (Factura == null)
            {
                throw new Exception("");
            }

            _facturacionContext.Facturas.Remove(Factura);
            await _facturacionContext.SaveChangesAsync();

            return true;
        }

        public bool FacturaExists(int id)
        {
            return _facturacionContext.Facturas.Count(e => e.IdFactura == id) > 0;
        }

    }
}
