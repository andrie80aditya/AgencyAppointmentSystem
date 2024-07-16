using AgencyAppointmentSystem.Models;
using AgencyAppointmentSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgencyAppointmentSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost("book")]
        public async Task<IActionResult> BookAppointment([FromBody] AppointmentSchema request)
        {
            try
            {
                var result = await _appointmentService.BookAppointmentAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("date/{date}")]
        public async Task<IActionResult> GetAppointmentsForDate(DateTime date)
        {
            var appointments = await _appointmentService.GetAppointmentsForDateAsync(date);
            return Ok(appointments);
        }
    }
}
