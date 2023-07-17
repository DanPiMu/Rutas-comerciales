

using Microsoft.AspNetCore.Mvc;
using VuelingFinalExam.ApplicationService.Contracts;
using VuelingFinalExam.ApplicationService.Implementations;

namespace VuelingFinalExam.Controllers
{
    public class DistanceController : ControllerBase
    {

       private readonly IDistanceService _distanceService;
        public DistanceController(IDistanceService distanceService) {
            _distanceService = distanceService;
        }

        [HttpGet("routes")]
        public async Task<IActionResult> GetRoutes()
        {
            var routes = await _distanceService.GetAllRoutesAsync();
            return Ok(routes);
        }

    }
}
