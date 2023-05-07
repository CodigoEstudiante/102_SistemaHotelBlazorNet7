using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotel.Shared
{
    public class CategoriaDTO
    {
        public int IdCategoria { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string? Descripcion { get; set; }


        public override bool Equals(object o)
        {
            var other = o as CategoriaDTO;
            return other?.IdCategoria == IdCategoria;
        }
        public override int GetHashCode() => IdCategoria.GetHashCode();
        public override string ToString()
        {
            return Descripcion;
        }

    }
}
