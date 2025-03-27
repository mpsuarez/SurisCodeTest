using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurisCodeTest.Api.Models;
using SurisCodeTest.Persistence.Entities;
using SurisCodeTest.Services;

namespace SurisCodeTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReserveController : ControllerBase
    {

        private readonly ReserveService _reserveService;

        public ReserveController(ReserveService reserveService)
        {
            _reserveService = reserveService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var reserves = await _reserveService.GetAllReservesAsync();
            return Ok(reserves);
        }

        [HttpGet("GetForList")]
        public async Task<IActionResult> GetAllReservesforListAsync()
        {
            var reserves = await _reserveService.GetAllReservesforListAsync();
            return Ok(reserves);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NewReserveRequest newReserveRequest)
        {
            Reserve reserve = new Reserve()
            {
                Date = newReserveRequest.Date,
                ServiceWorkingTimeId = newReserveRequest.ServiceWorkingTimeId,
                Client = newReserveRequest.Client
            };

            var validationString = await _reserveService.CreateReserveAsync(reserve);
            return Ok(validationString);
        }

    }
}
