using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurisCodeTest.Services;

namespace SurisCodeTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceWorkingTimeController : ControllerBase
    {

        private readonly ServiceWorkingTimeService _serviceWorkingTimeService;
        public ServiceWorkingTimeController(ServiceWorkingTimeService serviceWorkingTimeService)
        {
            _serviceWorkingTimeService = serviceWorkingTimeService;
        }

        [HttpGet("{id}/GetServiceWorkingTimesByServiceId")]
        public async Task<IActionResult> Get(Guid id)
        {
            var serviceWorkingTimes = await _serviceWorkingTimeService.GetServiceWorkingTimesByServiceIdAsync(id);
            return Ok(serviceWorkingTimes);
        }

    }
}
