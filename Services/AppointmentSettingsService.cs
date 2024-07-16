using AgencyAppointmentSystem.Models;
using AgencyAppointmentSystem.Repositories;

namespace AgencyAppointmentSystem.Services
{
    public class AppointmentSettingsService : IAppointmentSettingsService
    {
        private readonly IRepository<AppointmentSetting> _settingRepository;

        public AppointmentSettingsService(IRepository<AppointmentSetting> settingRepository)
        {
            _settingRepository = settingRepository;
        }

        public async Task<AppointmentSetting> AddAppointmentSettingAsync(AppointmentSettingSchema request)
        {
            var check = await _settingRepository.GetAllAsync();
            if (check.Count() > 0)
            {
                throw new Exception("You can only set it once!");
            }

            var setting = new AppointmentSetting
            {
                MaxAppointmentsPerDay = request.MaxAppointmentsPerDay
            };

            await _settingRepository.AddAsync(setting);
            return setting;
        }

        public async Task<IEnumerable<AppointmentSetting>> GetAppointmentSettingAsync()
        {
            var setting = await _settingRepository.GetAllAsync();
            return setting;
        }
    }
}
