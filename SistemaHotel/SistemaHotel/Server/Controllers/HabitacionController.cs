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
    public class HabitacionController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IHabitacionRepositorio _habitacionRepositorio;
        public HabitacionController(IHabitacionRepositorio habitacionRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _habitacionRepositorio = habitacionRepositorio;
        }

        [HttpGet]
        [Route("Obtener/{idHabitacion}")]
        public async Task<IActionResult> Obtener(int idHabitacion)
        {
            ResponseDTO<HabitacionDTO> _ResponseDTO = new ResponseDTO<HabitacionDTO>();

            try
            {
                HabitacionDTO Modelo = new HabitacionDTO();

                IQueryable<Habitacion> query = await _habitacionRepositorio.Consultar( h => h.IdHabitacion == idHabitacion);
                query = query
                    .Include(r => r.IdEstadoHabitacionNavigation)
                    .Include(r => r.IdPisoNavigation)
                    .Include(r => r.IdCategoriaNavigation);

                Modelo = _mapper.Map<HabitacionDTO>(query.FirstOrDefault());

                _ResponseDTO = new ResponseDTO<HabitacionDTO>() { status = true, msg = "ok", value = Modelo };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<HabitacionDTO>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            ResponseDTO<List<HabitacionDTO>> _ResponseDTO = new ResponseDTO<List<HabitacionDTO>>();

            try
            {
                List<HabitacionDTO> ListaModelo = new List<HabitacionDTO>();

                IQueryable<Habitacion> query = await _habitacionRepositorio.Consultar();
                query = query
                    .Include(r => r.IdEstadoHabitacionNavigation)
                    .Include(r => r.IdPisoNavigation)
                    .Include(r => r.IdCategoriaNavigation);

                ListaModelo = _mapper.Map<List<HabitacionDTO>>(query.ToList());

                _ResponseDTO = new ResponseDTO<List<HabitacionDTO>>() { status = true, msg = "ok", value = ListaModelo };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<HabitacionDTO>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }


        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] HabitacionDTO request)
        {
            ResponseDTO<HabitacionDTO> _ResponseDTO = new ResponseDTO<HabitacionDTO>();
            try
            {
                Habitacion _habitacion = _mapper.Map<Habitacion>(request);

                Habitacion _habitacionCreada = await _habitacionRepositorio.Crear(_habitacion);

                if (_habitacionCreada.IdHabitacion != 0)
                    _ResponseDTO = new ResponseDTO<HabitacionDTO>() { status = true, msg = "ok", value = _mapper.Map<HabitacionDTO>(_habitacionCreada) };
                else
                    _ResponseDTO = new ResponseDTO<HabitacionDTO>() { status = false, msg = "No se pudo crear la habitacion" };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<HabitacionDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] HabitacionDTO request)
        {
            ResponseDTO<HabitacionDTO> _ResponseDTO = new ResponseDTO<HabitacionDTO>();
            try
            {
                Habitacion _modelo = _mapper.Map<Habitacion>(request);
                Habitacion _modeloParaEditar = await _habitacionRepositorio.Obtener(u => u.IdHabitacion == _modelo.IdHabitacion);

                if (_modeloParaEditar != null)
                {
                    _modeloParaEditar.Numero = _modelo.Numero;
                    _modeloParaEditar.Detalle = _modelo.Detalle;
                    _modeloParaEditar.Precio = _modelo.Precio;
                    _modeloParaEditar.IdEstadoHabitacion = _modelo.IdEstadoHabitacion;
                    _modeloParaEditar.IdPiso = _modelo.IdPiso;
                    _modeloParaEditar.IdCategoria = _modelo.IdCategoria;

                    bool respuesta = await _habitacionRepositorio.Editar(_modeloParaEditar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<HabitacionDTO>() { status = true, msg = "ok", value = _mapper.Map<HabitacionDTO>(_modeloParaEditar) };
                    else
                        _ResponseDTO = new ResponseDTO<HabitacionDTO>() { status = false, msg = "No se pudo editar la habitacion" };
                }
                else
                {
                    _ResponseDTO = new ResponseDTO<HabitacionDTO>() { status = false, msg = "No se encontró la habitacion" };
                }

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<HabitacionDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }



        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            ResponseDTO<string> _ResponseDTO = new ResponseDTO<string>();
            try
            {
                Habitacion _modeloEliminar = await _habitacionRepositorio.Obtener(u => u.IdHabitacion == id);
                if (_modeloEliminar != null)
                {

                    bool respuesta = await _habitacionRepositorio.Eliminar(_modeloEliminar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<string>() { status = true, msg = "ok", value = "" };
                    else
                        _ResponseDTO = new ResponseDTO<string>() { status = false, msg = "No se pudo eliminar la habitacion", value = "" };
                }

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<string>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }
    }
}
