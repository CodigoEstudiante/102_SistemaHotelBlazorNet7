using SistemaHotel.Shared;

namespace SistemaHotel.Client.Servicios.Contratos
{
    public interface ICategoriaServicio
    {
        Task<ResponseDTO<List<CategoriaDTO>>> Lista();
        Task<ResponseDTO<CategoriaDTO>> Crear(CategoriaDTO entidad);
        Task<bool> Editar(CategoriaDTO entidad);
        Task<bool> Eliminar(int id);
    }
}
