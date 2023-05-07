using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SistemaHotel.Server.Models;

public partial class DbhotelBlazorContext : DbContext
{
    public DbhotelBlazorContext()
    {
    }

    public DbhotelBlazorContext(DbContextOptions<DbhotelBlazorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<EstadoHabitacion> EstadoHabitacions { get; set; }

    public virtual DbSet<Habitacion> Habitacions { get; set; }

    public virtual DbSet<Piso> Pisos { get; set; }

    public virtual DbSet<Recepcion> Recepcions { get; set; }

    public virtual DbSet<RolUsuario> RolUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__A3C02A108F660B58");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__D5946642FBB66E30");

            entity.ToTable("Cliente");

            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Documento)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EstadoHabitacion>(entity =>
        {
            entity.HasKey(e => e.IdEstadoHabitacion).HasName("PK__EstadoHa__EBF610CED0EBE3BE");

            entity.ToTable("EstadoHabitacion");

            entity.Property(e => e.IdEstadoHabitacion).ValueGeneratedNever();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Habitacion>(entity =>
        {
            entity.HasKey(e => e.IdHabitacion).HasName("PK__Habitaci__8BBBF9012E939EA8");

            entity.ToTable("Habitacion");

            entity.Property(e => e.Detalle)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Numero)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Habitacions)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__Habitacio__IdCat__267ABA7A");

            entity.HasOne(d => d.IdEstadoHabitacionNavigation).WithMany(p => p.Habitacions)
                .HasForeignKey(d => d.IdEstadoHabitacion)
                .HasConstraintName("FK__Habitacio__IdEst__24927208");

            entity.HasOne(d => d.IdPisoNavigation).WithMany(p => p.Habitacions)
                .HasForeignKey(d => d.IdPiso)
                .HasConstraintName("FK__Habitacio__IdPis__25869641");
        });

        modelBuilder.Entity<Piso>(entity =>
        {
            entity.HasKey(e => e.IdPiso).HasName("PK__Piso__F2823D8A50458194");

            entity.ToTable("Piso");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Recepcion>(entity =>
        {
            entity.HasKey(e => e.IdRecepcion).HasName("PK__RECEPCIO__83F935CA42F6859B");

            entity.ToTable("RECEPCION");

            entity.Property(e => e.Adelanto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CostoPenalidad)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.FechaEntrada)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaSalida).HasColumnType("datetime");
            entity.Property(e => e.FechaSalidaConfirmacion).HasColumnType("datetime");
            entity.Property(e => e.Observacion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PrecioInicial).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PrecioRestante).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TotalPagado)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Recepcions)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__RECEPCION__IdCli__3F466844");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.Recepcions)
                .HasForeignKey(d => d.IdHabitacion)
                .HasConstraintName("FK__RECEPCION__IdHab__403A8C7D");
        });

        modelBuilder.Entity<RolUsuario>(entity =>
        {
            entity.HasKey(e => e.IdRolUsuario).HasName("PK__RolUsuar__3FC7F91F39267462");

            entity.ToTable("RolUsuario");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97FB44B18C");

            entity.ToTable("Usuario");

            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolUsuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRolUsuario)
                .HasConstraintName("FK__Usuario__IdRolUs__34C8D9D1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
