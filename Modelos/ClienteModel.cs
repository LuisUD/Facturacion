using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class ClienteModel
    {
        public int IdCliente { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimineto { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public DateTime UltimaFechaCompra { get; set; }
        public DateTime ProximaFechaCompra { get; set; }

    }
}
