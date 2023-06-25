using DentistCalendar.Data.Entity;
using System.Collections.Generic;

namespace shopapp.webui.Models
{
    public class UserDetailsModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Tc { get; set; }

        public IEnumerable<string> SelectedRoles { get; set; }
        public IEnumerable<Appointment> AktifRandevu { get; set; }
        public IEnumerable<Appointment> GecmisRandevu { get; set; }
    }
}