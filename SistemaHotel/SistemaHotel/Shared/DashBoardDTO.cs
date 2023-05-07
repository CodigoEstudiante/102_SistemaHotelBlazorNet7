using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotel.Shared
{
    public class DashBoardDTO
    {
        public int TotalHabitaciones { get; set; }
        public int TotalHabitacionesDisponibles { get; set; }
        public int TotalHabitacionesOcupadas { get; set; }
        public int TotalHabitacionesEnLimpieza {get; set; }
       
    }
}
