using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class FacturaModel
    {
        public int IdFactura { get; set; }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public double Valor { get; set; }
        public double ValorTotal { get; set; }
        public DateTime FechaFacturacion { get; set; }


    }
}
