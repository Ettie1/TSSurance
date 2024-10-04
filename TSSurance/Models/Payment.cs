using System;
using System.ComponentModel.DataAnnotations;

namespace TSSurance.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        public int PolicyholderId { get; set; }
        //public virtual PolicyHolder Policyholder { get; set; }

        //[Required]
        public int PolicyId { get; set; }
        public virtual Policy Policy { get; set; }

        //[Required]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }

        //[Required]
        [Range(0, double.MaxValue)]
        public double Amount { get; set; }

        //[Required]
        //[StringLength(50)]
        //public string PaymentMethod { get; set; } // e.g., Credit Card, Bank Transfer, etc.
        public PaymentMethod PaymentMethod { get; set; }


    }

    public enum PaymentMethod
    {
        Cash, Bank_Transfer
    }
}
