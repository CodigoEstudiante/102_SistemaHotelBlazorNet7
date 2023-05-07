using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotel.Shared
{
    public class HabitacionDTO
    {
        public int IdHabitacion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string? Numero { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string? Detalle { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public decimal? Precio { get; set; }
        public int? IdEstadoHabitacion { get; set; }
        public int? IdPiso { get; set; }
        public int? IdCategoria { get; set; }

        public virtual CategoriaDTO? IdCategoriaNavigation { get; set; }

        public virtual EstadoHabitacionDTO? IdEstadoHabitacionNavigation { get; set; }

        public virtual PisoDTO? IdPisoNavigation { get; set; }

    }
}
