using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DentistCalendar.Models
{
    public class AddBlogViewModel
    {
        public int BlogId { get; set; }

        [Required(ErrorMessage = "Lütfen Blog Adını Belirtiniz.")]
        [StringLength(25)]
        public string BlogName { get; set; }

        [Required(ErrorMessage = "Lütfen Blog Başlığını Belirtiniz.")]
        [StringLength(75)]
        public string BlogTitle { get; set; }

        [Required(ErrorMessage = "Lütfen Blog İçeriğini Belirtiniz.")]
        public string BlogContent { get; set; }

        [Required(ErrorMessage = "Lütfen Blog Resmini Belirtiniz.")]
        public IFormFile ImageUrl { get; set; }
        public string Image { get; set; }
    }
}
