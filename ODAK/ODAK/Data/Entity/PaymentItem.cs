namespace DentistCalendar.Data.Entity
{
    public class PaymentItem
    {
        public int Id { get; set; }
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
        public int AppointmentId { get; set; }
        public double PaymentPrice { get; set; }
        public Appointment Appointment { get; set; }
    }
}
