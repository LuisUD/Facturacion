using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class InputCrearFactura
    {
        public FacturaModel Factura { get; set; }
        public IList<VentaModel> Ventas { get; set; }
    }
}
