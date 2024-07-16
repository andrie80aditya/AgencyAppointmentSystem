using AgencyAppointmentSystem.Models;
using AgencyAppointmentSystem.Repositories;

namespace AgencyAppointmentSystem.Services
{
    public class HolidayService : IHolidayService
    {
        private readonly IRepository<Holiday> _holidayRepository;

        public HolidayService(IRepository<Holiday> holidayRepository)
        {
            _holidayRepository = holidayRepository;
        }

        public async Task<Holiday> AddHolidayAsync(HolidaySchema request)
        {
            var check = await _holidayRepository.GetAllAsync();
            var checkHoliday = check.FirstOrDefault(a => a.Date.Date == request.Date);
            if (checkHoliday != null)
            {
                throw new Exception("Duplicate holiday dates!");
            }

            var holiday = new Holiday
            {
                Date = request.Date
            };

            await _holidayRepository.AddAsync(holiday);
            return holiday;
        }

        public async Task<IEnumerable<Holiday>> GetHolidaysAsync()
        {
            var holiday = await _holidayRepository.GetAllAsync();
            return holiday;
        }
    }
}
