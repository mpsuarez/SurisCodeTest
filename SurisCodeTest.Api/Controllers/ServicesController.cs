using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurisCodeTest.Services;

namespace SurisCodeTest.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ServicesController : ControllerBase
    {

        private readonly ServiceService _serviceService;

        public ServicesController(ServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var services = await _serviceService.GetAllServicesAsync();
            return Ok(services);
        }

    }
}
