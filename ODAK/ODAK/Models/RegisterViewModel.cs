using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentistCalendar.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen adınızı belirtiniz.")]
        [Display(Name = "Adınız:")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Lütfen soyadınız belirtiniz.")]
        [Display(Name = "Soyadınız:")]
        public string Surname { get; set; }



        [Required(ErrorMessage ="Lütfen kullanıcı adını belirtiniz.")]
        [Display(Name="Kullanıcı Adınız:")]
        public string UserName { get; set; }



        [Required(ErrorMessage = "Lütfen TC kimlik Numaranızı belirtiniz.")]
        [Display(Name = "Tc:")]
        [MinLength(10, ErrorMessage = "TC Kimlik Numaranız 11 haneden oluşmalıdır!"), MaxLength(11, ErrorMessage = "TC Kimlik Numaranız 11 haneden oluşmalıdır!")]

        public string TC { get; set; }



        [Required(ErrorMessage = "Lütfen telefon numaranızı belirtiniz.")]
        [Display(Name = "Tel No:")]
        [Phone(ErrorMessage = "Lütfen Telefon Numarası alanını kontrol ediniz.")]
        [MinLength(10, ErrorMessage = "Telefon Numaranız 11 haneden oluşmalıdır!"), MaxLength(11, ErrorMessage = "Telefon Numaranız 11 haneden oluşmalıdır!")]

        public string PhoneNumber { get; set; }



        [Required(ErrorMessage = "Lütfen emailinizi belirtiniz.")]
        [Display(Name = "Emailiniz:")]
        [EmailAddress(ErrorMessage = "Lütfen email alanını kontrol ediniz.")]
        public string Email { get; set; }



        [Required(ErrorMessage = "Lütfen şifrenizi belirtiniz.")]
        [Display(Name = "Şifreniz:")]
        [DataType(DataType.Password)]
        public string  Password { get; set; }


        [Required(ErrorMessage = "Lütfen şifrenizi belirtiniz.")]
        [Display(Name = "Şifreniz:")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Parolanız Aynı Olmalıdır")]
        public string RePassword { get; set; }




        [Display(Name = "Randevu Rengi:")]
        public string Color { get; set; }
       
        [Display(Name = "Doktorum")]
        public bool IsDentist { get; set; }

        
    }
}
