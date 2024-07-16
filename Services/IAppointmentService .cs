using AgencyAppointmentSystem.Models;

namespace AgencyAppointmentSystem.Services
{
    public interface IAppointmentService
    {
        Task<Appointment> BookAppointmentAsync(AppointmentSchema request);
        Task<IEnumerable<Appointment>> GetAppointmentsForDateAsync(DateTime date);
    }
}
