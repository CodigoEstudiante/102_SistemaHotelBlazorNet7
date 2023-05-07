using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaHotel.Server.Models;
using SistemaHotel.Server.Repositorio.Contratos;
using SistemaHotel.Server.Repositorio.Implementacion;
using SistemaHotel.Shared;

namespace SistemaHotel.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecepcionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRecepcionRepositorio _recepcionRepositorio;
        public RecepcionController(IRecepcionRepositorio recepcionRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _recepcionRepositorio = recepcionRepositorio;
        }

        [HttpGet]
        [Route("Obtener/{idHabitacion}")]
        public async Task<IActionResult> Obtener(int idHabitacion)
        {
            ResponseDTO<RecepcionDTO> _ResponseDTO = new ResponseDTO<RecepcionDTO>();

            try
            {
                RecepcionDTO Modelo = new RecepcionDTO();

                IQueryable<Recepcion> query = await _recepcionRepositorio.Consultar(h => h.IdHabitacion == idHabitacion && h.Estado == true);
                query = query
                    .Include(r => r.IdClienteNavigation)
                    .Include(r => r.IdHabitacionNavigation).ThenInclude(r => r.IdCategoriaNavigation)
                    .Include(r => r.IdHabitacionNavigation).ThenInclude(r => r.IdPisoNavigation);

                Modelo = _mapper.Map<RecepcionDTO>(query.FirstOrDefault());

                _ResponseDTO = new ResponseDTO<RecepcionDTO>() { status = true, msg = "ok", value = Modelo };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<RecepcionDTO>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] RecepcionDTO request)
        {
            ResponseDTO<RecepcionDTO> _ResponseDTO = new ResponseDTO<RecepcionDTO>();
            try
            {
                Recepcion _modelo = _mapper.Map<Recepcion>(request);

                Recepcion _modeloCreado = await _recepcionRepositorio.Crear(_modelo);

                if (_modeloCreado.IdRecepcion != 0)
                    _ResponseDTO = new ResponseDTO<RecepcionDTO>() { status = true, msg = "ok", value = _mapper.Map<RecepcionDTO>(_modeloCreado) };
                else
                    _ResponseDTO = new ResponseDTO<RecepcionDTO>() { status = false, msg = "No se pudo crear la Recepcion" };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<RecepcionDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] RecepcionDTO request)
        {
            ResponseDTO<RecepcionDTO> _ResponseDTO = new ResponseDTO<RecepcionDTO>();
            try
            {
                Recepcion _modelo = _mapper.Map<Recepcion>(request);

               bool respuesta = await _recepcionRepositorio.Editar(_modelo);

               if (respuesta)
                   _ResponseDTO = new ResponseDTO<RecepcionDTO>() { status = true, msg = "ok", value = _mapper.Map<RecepcionDTO>(_mapper.Map<RecepcionDTO>(_modelo)) };
               else
                   _ResponseDTO = new ResponseDTO<RecepcionDTO>() { status = false, msg = "No se pudo editar la Recepcion" };
              
                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<RecepcionDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpGet]
        [Route("Reporte")]
        public async Task<IActionResult> Reporte(string? fechaInicio, string? fechaFin)
        {
            ResponseDTO<List<ReporteDTO>> _ResponseDTO = new ResponseDTO<List<ReporteDTO>>();
            try
            {
                List<ReporteDTO> listaReporte = _mapper.Map<List<ReporteDTO>>(await _recepcionRepositorio.Reporte(fechaInicio, fechaFin));
                _ResponseDTO = new ResponseDTO<List<ReporteDTO>>() { status = true, msg = "ok", value = listaReporte };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<ReporteDTO>>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);

            }

        }

    }
}
