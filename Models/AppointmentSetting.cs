namespace AgencyAppointmentSystem.Models
{
    public class AppointmentSetting
    {
        public int Id { get; set; }
        public int MaxAppointmentsPerDay { get; set; }
    }

    public class AppointmentSettingSchema
    {
        public int MaxAppointmentsPerDay { get; set; }
    }
}
