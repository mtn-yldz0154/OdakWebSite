using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentistCalendar.Data.Entity
{
    public class Appointment
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        public string PatientName { get; set; }
        [Required]
        public string PatientSurname { get; set; }
    
        public string DoctorName { get; set; }
    
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        [Required]
        public bool Paid { get; set; }
        public bool OnlinePaid { get; set; }
        public double Price { get; set; }

        [Required]
        [MaxLength(11)]
        [MinLength(11)]
        public string Tc { get; set; }
    }
}
