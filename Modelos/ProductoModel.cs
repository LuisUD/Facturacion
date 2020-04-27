using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class ProductoModel
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public double IVA { get; set; }
        public int Cantidad { get; set; }
        public double PrecioInventario { get; set; }
        public double ValorTotal { get; set; }

        public virtual List<VentaModel> Ventas { get; set; }

    }
}
