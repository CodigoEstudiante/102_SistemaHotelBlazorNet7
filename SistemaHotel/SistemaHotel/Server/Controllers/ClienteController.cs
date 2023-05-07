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
    public class ClienteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteController(IClienteRepositorio clienteRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _clienteRepositorio = clienteRepositorio;
        }


        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            ResponseDTO<List<ClienteDTO>> _ResponseDTO = new ResponseDTO<List<ClienteDTO>>();

            try
            {
                List<ClienteDTO> ListaModelo = new List<ClienteDTO>();

                ListaModelo = _mapper.Map<List<ClienteDTO>>(await _clienteRepositorio.Lista());

                _ResponseDTO = new ResponseDTO<List<ClienteDTO>>() { status = true, msg = "ok", value = ListaModelo };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<ClienteDTO>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }


        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] ClienteDTO request)
        {
            ResponseDTO<ClienteDTO> _ResponseDTO = new ResponseDTO<ClienteDTO>();
            try
            {
                Cliente _categoria = _mapper.Map<Cliente>(request);

                Cliente _categoriaCreada = await _clienteRepositorio.Crear(_categoria);

                if (_categoriaCreada.IdCliente != 0)
                    _ResponseDTO = new ResponseDTO<ClienteDTO>() { status = true, msg = "ok", value = _mapper.Map<ClienteDTO>(_categoriaCreada) };
                else
                    _ResponseDTO = new ResponseDTO<ClienteDTO>() { status = false, msg = "No se pudo crear el cliente" };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<ClienteDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] ClienteDTO request)
        {
            ResponseDTO<ClienteDTO> _ResponseDTO = new ResponseDTO<ClienteDTO>();
            try
            {
                Cliente _modelo = _mapper.Map<Cliente>(request);
                Cliente _modeloParaEditar = await _clienteRepositorio.Obtener(u => u.IdCliente == _modelo.IdCliente);

                if (_modeloParaEditar != null)
                {
                    _modeloParaEditar.TipoDocumento = _modelo.TipoDocumento;
                    _modeloParaEditar.Documento = _modelo.Documento;
                    _modeloParaEditar.NombreCompleto = _modelo.NombreCompleto;
                    _modeloParaEditar.Correo = _modelo.Correo;

                    bool respuesta = await _clienteRepositorio.Editar(_modeloParaEditar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<ClienteDTO>() { status = true, msg = "ok", value = _mapper.Map<ClienteDTO>(_modeloParaEditar) };
                    else
                        _ResponseDTO = new ResponseDTO<ClienteDTO>() { status = false, msg = "No se pudo editar el Cliente" };
                }
                else
                {
                    _ResponseDTO = new ResponseDTO<ClienteDTO>() { status = false, msg = "No se encontró el Cliente" };
                }

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<ClienteDTO>() { status = false, msg = ex.Message };
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
                Cliente _modeloEliminar = await _clienteRepositorio.Obtener(u => u.IdCliente == id);
                if (_modeloEliminar != null)
                {

                    bool respuesta = await _clienteRepositorio.Eliminar(_modeloEliminar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<string>() { status = true, msg = "ok", value = "" };
                    else
                        _ResponseDTO = new ResponseDTO<string>() { status = false, msg = "No se pudo eliminar el Cliente", value = "" };
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
