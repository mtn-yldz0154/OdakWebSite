using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DentistCalendar.Models
{
    public class CommentViewModel
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Lütfen adınızı belirtiniz.")]
        [Display(Name = "Adınız:")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen soyadınızı belirtiniz.")]
        [Display(Name = "Soyadınız:")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Lütfen puanınızı belirtiniz.")]
        [Display(Name = "Puanınız:")]
    
        public int Puan { get; set; }
        [Required(ErrorMessage = "Lütfen Yorum Başlığını belirtiniz.")]
        [Display(Name = "Yorum Başlığı:")]
        [StringLength(15)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Lütfen Yorumunuzu belirtiniz.")]
        [Display(Name = "Yorum İçeriği:")]
        [StringLength(45)]
        public string Description { get; set; }
        public bool Confirm { get; set; }
        public string PP { get; set; }
    }
}
