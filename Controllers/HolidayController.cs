using AgencyAppointmentSystem.Models;
using AgencyAppointmentSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgencyAppointmentSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HolidayController : ControllerBase
    {
        private readonly IHolidayService _holidayService;

        public HolidayController(IHolidayService holidayService)
        {
            _holidayService = holidayService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Addholiday([FromBody] HolidaySchema request)
        {
            try
            {
                var result = await _holidayService.AddHolidayAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetHolidayList()
        {
            var holidays = await _holidayService.GetHolidaysAsync();
            return Ok(holidays);
        }
    }
}
