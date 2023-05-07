using System;
using System.Collections.Generic;

namespace SistemaHotel.Server.Models;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Habitacion> Habitacions { get; } = new List<Habitacion>();
}
