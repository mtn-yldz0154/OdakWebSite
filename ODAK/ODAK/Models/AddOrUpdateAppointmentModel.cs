using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistCalendar.Models
{
    public class AddOrUpdateAppointmentModel
    {
        public int Id { get; set; }
        public string TC { get; set; }
        public string UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string DoctorName { get; set; }
    }
}
