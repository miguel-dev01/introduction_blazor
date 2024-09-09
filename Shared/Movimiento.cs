using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace blazor_test.Shared
{
    public class Movimiento
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        public Double Cantidad { get; set; }

        public String Tipo { get; set; } = String.Empty; // Ingreso o Egreso

        public String Descripcion { get; set; } = String.Empty;

        public Usuario? Usuario { get; set; }

        public int UsuarioId { get; set; }
    }
}
