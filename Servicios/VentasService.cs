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
    public class VentasService
    {
        private readonly FacturacionContext _facturacionContext;

        public VentasService(FacturacionContext facturacionContext)
        {

            _facturacionContext = facturacionContext;
        }

        public IList<VentaModel> GetVentas()
        {
            return _facturacionContext.Ventas.ProjectToList<VentaModel>();
        }

        public async Task<Venta> GetVenta(int id)
        {
            Venta Venta = await _facturacionContext.Ventas.FindAsync(id);
            if (Venta == null)
            {
                throw new Exception("");
            }

            return Venta;
        }


        public IList<VentaModel> GetVentasPorFactura(int id)
        {
            var ventas = _facturacionContext.Ventas.Where(v => v.Factura.IdFactura == id).ProjectToList<VentaModel>();

            return ventas;
        }

        public async Task<Venta> PutVenta(int id, Venta Venta)
        {

            _facturacionContext.Entry(Venta).State = EntityState.Modified;

            try
            {
                await _facturacionContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaExists(id))
                {
                    throw new Exception("");
                }
                else
                {
                    throw;
                }
            }

            return Venta;
        }


        public async Task<Venta> PostVenta(Venta Venta)
        {

            _facturacionContext.Ventas.Add(Venta);
            await _facturacionContext.SaveChangesAsync();

            return Venta;
        }


        public async Task<bool> DeleteVenta(int id)
        {
            Venta Venta = await _facturacionContext.Ventas.FindAsync(id);
            if (Venta == null)
            {
                throw new Exception("");
            }

            _facturacionContext.Ventas.Remove(Venta);
            await _facturacionContext.SaveChangesAsync();

            return true;
        }

        public bool VentaExists(int id)
        {
            return _facturacionContext.Ventas.Count(e => e.IdVenta == id) > 0;
        }


    }
}
