using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaHotel.Server.Models;
using SistemaHotel.Server.Repositorio.Contratos;
using SistemaHotel.Shared;

namespace SistemaHotel.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolUsuarioController : ControllerBase
    {
        
        private readonly IMapper _mapper;
        private readonly IRolUsuarioRepositorio _rolUsuarioRepositorio;
        public RolUsuarioController(IRolUsuarioRepositorio rolUsuarioRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _rolUsuarioRepositorio = rolUsuarioRepositorio;
        }


        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            ResponseDTO<List<RolUsuarioDTO>> _ResponseDTO = new ResponseDTO<List<RolUsuarioDTO>>();

            try
            {
                List<RolUsuarioDTO> ListaRolUsuario= new List<RolUsuarioDTO>();
                ListaRolUsuario = _mapper.Map<List<RolUsuarioDTO>>(await _rolUsuarioRepositorio.Lista());

                _ResponseDTO = new ResponseDTO<List<RolUsuarioDTO>>() { status = true, msg = "ok", value = ListaRolUsuario };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<RolUsuarioDTO>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }
    }
}
