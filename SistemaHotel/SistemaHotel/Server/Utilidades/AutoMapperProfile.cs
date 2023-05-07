using AutoMapper;
using SistemaHotel.Server.Models;
using SistemaHotel.Shared;

namespace SistemaHotel.Server.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region RolUsuario
            CreateMap<Categoria, CategoriaDTO>();
            CreateMap<CategoriaDTO, Categoria>();
            #endregion RolUsuario

            #region RolUsuario
            CreateMap<RolUsuario, RolUsuarioDTO>();
            CreateMap<RolUsuarioDTO, RolUsuario>();
            #endregion RolUsuario


            #region Usuario
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<UsuarioDTO, Usuario>()
            .ForMember(destino =>
                    destino.Estado,
                    opt => opt.MapFrom(src => true)
                ).ForMember(destino =>
                    destino.IdRolUsuarioNavigation,
                    opt => opt.Ignore()
                );
            #endregion Usuario

            #region Cliente
            CreateMap<Cliente, ClienteDTO>();
            CreateMap<ClienteDTO, Cliente>()
            .ForMember(destino =>
                    destino.Estado,
                    opt => opt.MapFrom(src => true)
                );
            #endregion Cliente

            #region EstadoHabitacion
            CreateMap<EstadoHabitacion, EstadoHabitacionDTO>();
            CreateMap<EstadoHabitacionDTO, EstadoHabitacion>();
            #endregion EstadoHabitacion

            #region Piso
            CreateMap<Piso, PisoDTO>();
            CreateMap<PisoDTO, Piso>();
            #endregion Piso


            #region Habitacion
            CreateMap<Habitacion, HabitacionDTO>();
            CreateMap<HabitacionDTO, Habitacion>()
            .ForMember(destino =>
                    destino.Estado,
                    opt => opt.MapFrom(src => true)
                );
            #endregion Habitacion

            #region Recepcion
            CreateMap<Recepcion, RecepcionDTO>();
            CreateMap<RecepcionDTO, Recepcion>()
            .ForMember(destino =>
                    destino.Estado,
                    opt => opt.MapFrom(src => true)
                );

            CreateMap<Recepcion, ReporteDTO>()
                .ForMember(destino =>
                    destino.NombreCliente,
                    opt => opt.MapFrom(src => src.IdClienteNavigation.NombreCompleto)
                )
                .ForMember(destino =>
                    destino.TipoDocumento,
                    opt => opt.MapFrom(src => src.IdClienteNavigation.TipoDocumento)
                )
                 .ForMember(destino =>
                    destino.NroDocumento,
                    opt => opt.MapFrom(src => src.IdClienteNavigation.Documento)
                )
                  .ForMember(destino =>
                    destino.NroHabitacion,
                    opt => opt.MapFrom(src => src.IdHabitacionNavigation.Numero)
                )
                   .ForMember(destino =>
                    destino.FechaEntrada,
                    opt => opt.MapFrom(src => src.FechaEntrada.Value.ToString("dd/MM/yyyy"))
                )
                     .ForMember(destino =>
                    destino.FechaSalida,
                    opt => opt.MapFrom(src => src.FechaSalida.Value.ToString("dd/MM/yyyy"))
                )
                     .ForMember(destino =>
                    destino.TotalPagado,
                    opt => opt.MapFrom(src => src.TotalPagado.ToString())
                )
                ;
            #endregion Recepcion
        }
    }
}
