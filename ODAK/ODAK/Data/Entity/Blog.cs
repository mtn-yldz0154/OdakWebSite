namespace DentistCalendar.Data.Entity
{
    public class Blog
    {
        public int Id { get; set; }
        public string BlogName { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string BlogImageUrl { get; set; }
        public string DoctorId { get; set;}
    }
}
