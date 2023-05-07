using System;
using System.Collections.Generic;

namespace SistemaHotel.Server.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? NombreCompleto { get; set; }

    public string? Correo { get; set; }

    public int? IdRolUsuario { get; set; }

    public string? Clave { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual RolUsuario? IdRolUsuarioNavigation { get; set; }
}
