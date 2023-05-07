using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotel.Shared
{
    public class ReporteDTO
    {
        public string NombreCliente { get; set; }
        public string TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string NroHabitacion { get; set; }
        public string FechaEntrada { get; set; }
        public string FechaSalida { get; set; }
        public string TotalPagado { get; set; }

    }
}
