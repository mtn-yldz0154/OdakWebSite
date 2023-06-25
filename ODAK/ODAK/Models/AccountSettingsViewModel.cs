

using Microsoft.AspNetCore.Http;

namespace DentistCalendar.Models
{
    public class AccountSettingsViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TC { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public IFormFile ImageUrl { get; set; }
        public string Image { get; set; }
      

    }
}
