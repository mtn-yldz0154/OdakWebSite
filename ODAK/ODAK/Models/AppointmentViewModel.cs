using System;

namespace DentistCalendar
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public string TC { get; set; }
        public string Dentist { get; internal set; }
        public string PatientName { get; internal set; }
        public string PatientSurname { get; internal set; }
        public DateTime StartDate { get; internal set; }
        public DateTime EndDate { get; internal set; }
        public string Description { get; internal set; }
        public string PhoneNumber { get; internal set; }
        public string UserId { get; internal set; }
        public string Color { get; internal set; }
        public bool Paid { get; internal set; }
    }
}