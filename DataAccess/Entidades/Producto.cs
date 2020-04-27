using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entidades
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public double IVA { get; set; }
        public int Cantidad { get; set; }
        public double PrecioInventario { get; set; }

        public virtual List<Venta> Ventas { get; set; }

    }
}
