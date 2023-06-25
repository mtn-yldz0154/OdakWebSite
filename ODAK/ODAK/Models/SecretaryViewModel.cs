using DentistCalendar.Data.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistCalendar.Models
{
    public class SecretaryViewModel
    {
        public string Tc { get; set; }
        public AppUser User { get; set; }
        public IEnumerable<AppUser> Dentists { get; set; }
        public List<SelectListItem> DentistsSelectList { get; internal set; }
        public List<Appointment> NewAppointment { get; set; }
        public string DoctorName { get; set; }

        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PatientName { get; set; }
        public string ImageUrl { get; set; }
        public string PatientSurname { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public bool Paid { get; set; }
 

        public CommentViewModel CommentViewModel { get; set; }
        public AddBlogViewModel AddBlogViewModel { get; set; }
        public PaymentModel PaymentModel { get; set; }


    }
}
