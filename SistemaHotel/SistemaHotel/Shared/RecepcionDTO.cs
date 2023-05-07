using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotel.Shared
{
    public class RecepcionDTO
    {
        public int IdRecepcion { get; set; }

        public int? IdCliente { get; set; }

        public int? IdHabitacion { get; set; }

        public DateTime? FechaEntrada { get; set; }

        public DateTime? FechaSalida { get; set; }

        public DateTime? FechaSalidaConfirmacion { get; set; }

        public decimal? PrecioInicial { get; set; }

        public decimal? Adelanto { get; set; }

        public decimal? PrecioRestante { get; set; }

        public decimal? TotalPagado { get; set; }

        public decimal? CostoPenalidad { get; set; }

        public string? Observacion { get; set; }

        public bool? Estado { get; set; }

        public virtual ClienteDTO? IdClienteNavigation { get; set; }

        public virtual HabitacionDTO? IdHabitacionNavigation { get; set; }
    }
}
