using AgencyAppointmentSystem.Models;

namespace AgencyAppointmentSystem.Services
{
    public interface IAppointmentSettingsService
    {
        Task<AppointmentSetting> AddAppointmentSettingAsync(AppointmentSettingSchema request);
        Task<IEnumerable<AppointmentSetting>> GetAppointmentSettingAsync();
    }
}
