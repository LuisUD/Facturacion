using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entidades
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimineto { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public virtual List<Factura> Facturas { get; set; }
    }
}
