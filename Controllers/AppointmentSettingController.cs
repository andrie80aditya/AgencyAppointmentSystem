using AgencyAppointmentSystem.Models;
using AgencyAppointmentSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgencyAppointmentSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentSettingController : ControllerBase
    {
        private readonly IAppointmentSettingsService _settingService;

        public AppointmentSettingController(IAppointmentSettingsService settingService)
        {
            _settingService = settingService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAppointmentSetting([FromBody] AppointmentSettingSchema request)
        {
            try
            {
                var result = await _settingService.AddAppointmentSettingAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointmentSettingList()
        {
            var setting = await _settingService.GetAppointmentSettingAsync();
            return Ok(setting);
        }
    }
}
