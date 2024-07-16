using AgencyAppointmentSystem.Models;

namespace AgencyAppointmentSystem.Services
{
    public interface IHolidayService
    {
        Task<Holiday> AddHolidayAsync(HolidaySchema request);
        Task<IEnumerable<Holiday>> GetHolidaysAsync();
    }
}
