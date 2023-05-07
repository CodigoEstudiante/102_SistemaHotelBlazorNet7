using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaHotel.Server.Models;
using SistemaHotel.Server.Repositorio.Contratos;
using SistemaHotel.Server.Repositorio.Implementacion;
using SistemaHotel.Shared;

namespace SistemaHotel.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PisoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPisoRepositorio _pisoRepositorio;
        public PisoController(IPisoRepositorio pisoRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _pisoRepositorio = pisoRepositorio;
        }


        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            ResponseDTO<List<PisoDTO>> _ResponseDTO = new ResponseDTO<List<PisoDTO>>();

            try
            {
                List<PisoDTO> ListaModelo = new List<PisoDTO>();

                ListaModelo = _mapper.Map<List<PisoDTO>>(await _pisoRepositorio.Lista());

                _ResponseDTO = new ResponseDTO<List<PisoDTO>>() { status = true, msg = "ok", value = ListaModelo };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<PisoDTO>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }


        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] PisoDTO request)
        {
            ResponseDTO<PisoDTO> _ResponseDTO = new ResponseDTO<PisoDTO>();
            try
            {
                Piso _categoria = _mapper.Map<Piso>(request);

                Piso _categoriaCreada = await _pisoRepositorio.Crear(_categoria);

                if (_categoriaCreada.IdPiso != 0)
                    _ResponseDTO = new ResponseDTO<PisoDTO>() { status = true, msg = "ok", value = _mapper.Map<PisoDTO>(_categoriaCreada) };
                else
                    _ResponseDTO = new ResponseDTO<PisoDTO>() { status = false, msg = "No se pudo crear el Piso" };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<PisoDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] PisoDTO request)
        {
            ResponseDTO<PisoDTO> _ResponseDTO = new ResponseDTO<PisoDTO>();
            try
            {
                Piso _modelo = _mapper.Map<Piso>(request);
                Piso _modeloParaEditar = await _pisoRepositorio.Obtener(u => u.IdPiso == _modelo.IdPiso);

                if (_modeloParaEditar != null)
                {
                    _modeloParaEditar.Descripcion = _modelo.Descripcion;

                    bool respuesta = await _pisoRepositorio.Editar(_modeloParaEditar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<PisoDTO>() { status = true, msg = "ok", value = _mapper.Map<PisoDTO>(_modeloParaEditar) };
                    else
                        _ResponseDTO = new ResponseDTO<PisoDTO>() { status = false, msg = "No se pudo editar el piso" };
                }
                else
                {
                    _ResponseDTO = new ResponseDTO<PisoDTO>() { status = false, msg = "No se encontró el piso" };
                }

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<PisoDTO>() { status = false, msg = ex.Message };
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
                Piso _modeloEliminar = await _pisoRepositorio.Obtener(u => u.IdPiso == id);
                if (_modeloEliminar != null)
                {

                    bool respuesta = await _pisoRepositorio.Eliminar(_modeloEliminar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<string>() { status = true, msg = "ok", value = "" };
                    else
                        _ResponseDTO = new ResponseDTO<string>() { status = false, msg = "No se pudo eliminar el piso", value = "" };
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
