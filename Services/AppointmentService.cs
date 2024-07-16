using AgencyAppointmentSystem.Models;
using AgencyAppointmentSystem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AgencyAppointmentSystem.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository<Appointment> _appointmentRepository;
        private readonly IRepository<Holiday> _holidayRepository;
        private readonly IRepository<AppointmentSetting> _settingsRepository;

        public AppointmentService(IRepository<Appointment> appointmentRepository, IRepository<Holiday> holidayRepository, IRepository<AppointmentSetting> settingsRepository)
        {
            _appointmentRepository = appointmentRepository;
            _holidayRepository = holidayRepository;
            _settingsRepository = settingsRepository;
        }

        public async Task<Appointment> BookAppointmentAsync(AppointmentSchema request)
        {
            int maxAppointmentsPerDay = 0;
            var settings = await _settingsRepository.GetByIdAsync(1);
            if (settings != null) 
            {
                maxAppointmentsPerDay = settings.MaxAppointmentsPerDay;
            }
            
            var holiday = await _holidayRepository.GetAllAsync();
            var holidayByDate = holiday.FirstOrDefault(a => a.Date.Date == request.Date);
            if (holidayByDate != null)
            {
                throw new Exception("Cannot book appointments on holidays");
            }

            var appointments = await _appointmentRepository.GetAllAsync();
            var date = request.Date;

            if (maxAppointmentsPerDay > 0)
            {
                while (appointments.Where(a => a.Date.Date == date).Count() >= maxAppointmentsPerDay)
                {
                    date = date.AddDays(1);

                    var holiday2 = await _holidayRepository.GetAllAsync();
                    var holidayByDate2 = holiday2.FirstOrDefault(a => a.Date.Date == date);
                    if (holidayByDate2 != null)
                    {
                        date = date.AddDays(1);
                    }
                }
            }

            var appointmentList = await _appointmentRepository.GetAllAsync();
            var tokenNumber = appointmentList.Where(a => a.Date.Date == date).Count() + 1;

            var appointment = new Appointment
            {
                Date = date,
                CustomerName = request.CustomerName,
                TokenNumber = tokenNumber
            };
            await _appointmentRepository.AddAsync(appointment);
            return appointment;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsForDateAsync(DateTime date)
        {
            var appointment = await _appointmentRepository.GetAllAsync();
            return appointment.Where(a => a.Date.Date == date);
        }
    }
}
