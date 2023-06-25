using System;
using System.Collections.Generic;

namespace DentistCalendar.Data.Entity
{
    public class Payment
    {
        public int Id { get; set; }
        public string PaymentNumber { get; set; }

        public DateTime PaymentDate { get; set; }
        public string UserId { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }

        public EnumPaymentState EnumPaymentState { get; set; }


        public List<PaymentItem> PaymentItems { get; set; }
    }

    public enum EnumPaymentState
    {
        waiting=0,
        unpaid=1,
        complated=2
    }
}
