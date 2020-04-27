using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entidades
{
    public class Factura
    {
        [Key]
        public int IdFactura { get; set; }
        public int IdCliente { get; set; }
        public double Valor { get; set; }
        public double ValorTotal { get; set; }
        public DateTime FechaFacturacion { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual List<Venta> Ventas { get; set; }

    }
}
