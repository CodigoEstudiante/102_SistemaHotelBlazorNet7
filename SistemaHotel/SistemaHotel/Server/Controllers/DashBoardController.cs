using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaHotel.Server.Repositorio.Contratos;
using SistemaHotel.Shared;

namespace SistemaHotel.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDashBoardRepositorio _dashboardRepositorio;
        public DashBoardController(IDashBoardRepositorio dashboardRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _dashboardRepositorio = dashboardRepositorio;
        }

        [HttpGet]
        [Route("Resumen")]
        public async Task<IActionResult> Resumen()
        {
            ResponseDTO<DashBoardDTO> _response = new ResponseDTO<DashBoardDTO>();

            try
            {
                DashBoardDTO vmDashboard = new DashBoardDTO();

                vmDashboard.TotalHabitaciones = await _dashboardRepositorio.TotalHabitaciones();
                vmDashboard.TotalHabitacionesDisponibles = await _dashboardRepositorio.HabitacionesDisponibles();
                vmDashboard.TotalHabitacionesEnLimpieza = await _dashboardRepositorio.HabitacionesLimpieza();
                vmDashboard.TotalHabitacionesOcupadas = await _dashboardRepositorio.HabitacionesOcupadas();

                _response = new ResponseDTO<DashBoardDTO>() { status = true, msg = "ok", value = vmDashboard };
                return StatusCode(StatusCodes.Status200OK, _response);

            }
            catch (Exception ex)
            {
                _response = new ResponseDTO<DashBoardDTO>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }

        }
    }
}
