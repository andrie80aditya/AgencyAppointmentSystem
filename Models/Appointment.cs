namespace AgencyAppointmentSystem.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string CustomerName { get; set; }
        public int TokenNumber { get; set; }
    }

    public class AppointmentSchema
    {
        public DateTime Date { get; set; }
        public string CustomerName { get; set; }
    }
}
