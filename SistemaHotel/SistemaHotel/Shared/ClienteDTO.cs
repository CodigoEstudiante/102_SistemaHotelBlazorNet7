using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotel.Shared
{
    public class ClienteDTO
    {
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "El campo Tipo Documento es requerido")]
        public string? TipoDocumento { get; set; }

        [Required(ErrorMessage = "El campo Documento es requerido")]
        public string? Documento { get; set; }

        [Required(ErrorMessage = "El campo Nombre Completo es requerido")]
        public string? NombreCompleto { get; set; }

        [Required(ErrorMessage = "El campo Correo es requerido")]
        public string? Correo { get; set; }
    }
}
