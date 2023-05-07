using System;
using System.Collections.Generic;

namespace SistemaHotel.Server.Models;

public partial class RolUsuario
{
    public int IdRolUsuario { get; set; }

    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
