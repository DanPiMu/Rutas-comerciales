

using Microsoft.AspNetCore.Mvc;
using Serilog;
using VuelingFinalExam.ApplicationService.Contracts;
using VuelingFinalExam.ApplicationService.Implementations;

namespace VuelingFinalExam.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/Imperio/[controller]")]

    public class DistanceController : ControllerBase
    {

       private readonly IDistanceService _distanceService;
        public DistanceController(IDistanceService distanceService) {
            _distanceService = distanceService;
        }

        [HttpGet("routes")]
        public async Task<IActionResult> GetRoutes()
        {
            try
            {
                var routes = await _distanceService.GetAllRoutesAsync();
                return Ok(routes);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error obteniendo las rutas");
                return StatusCode(500, "Ocurrió un error interno del servidor. Por favor intenta nuevamente más tarde.");
            }
        }

    }
}
