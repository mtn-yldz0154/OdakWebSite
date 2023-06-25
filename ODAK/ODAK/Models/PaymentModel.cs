using DentistCalendar.Data.Entity;
using System.Collections.Generic;
using System;

namespace DentistCalendar.Models
{
    public class PaymentModel
    {
        public int Id { get; set; }

        public SecretaryViewModel SecretaryViewModel { get; set; }
        public int AppointmentId { get; set; }
        public string PaymentNumber { get; set; }
        public DateTime PaymentDate { get; set; }
        public string UserId { get; set; }
        public string Phone { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string ExparitonMonth { get; set; }
        public string ExparitionYear { get; set; }
        public string CVV { get; set; }
        public string Email { get; set; }
        public double Seans { get; set; }
        public EnumPaymentState EnumPaymentState { get; set; }

        public List<PaymentItem> PaymentItems { get; set; }
    }
}
