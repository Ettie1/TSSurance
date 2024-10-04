using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TSSurance.Models
{
    public class Policy
    {
        [Key]
        public int PolicyId { get; set; }

        [Required]
        public int PolicyHolderId { get; set; }
        public virtual PolicyHolder PolicyHolder { get; set; }

        [Required]
        [StringLength(50)]
        public string PolicyNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double PremiumAmount { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double CoverageAmount { get; set; }

        public virtual ICollection<Beneficiary> Beneficiaries { get; set; }
    }
}
