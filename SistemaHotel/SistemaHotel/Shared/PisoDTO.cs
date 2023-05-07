using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotel.Shared
{
    public class PisoDTO
    {
        public int IdPiso { get; set; }

        public string? Descripcion { get; set; }

        public bool? Estado { get; set; }
        public override bool Equals(object o)
        {
            var other = o as PisoDTO;
            return other?.IdPiso == IdPiso;
        }
        public override int GetHashCode() => IdPiso.GetHashCode();
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
