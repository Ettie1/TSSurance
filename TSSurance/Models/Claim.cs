using System;
using System.ComponentModel.DataAnnotations;

namespace TSSurance.Models
{
    public class Claim
    {
        [Key]
        public int ClaimId { get; set; }

        [Required]
        public int PolicyId { get; set; }
        public virtual Policy Policy { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfClaim { get; set; }

        [Required]
        [StringLength(200)]
        public string ReasonForClaim { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double ClaimAmount { get; set; }

        public bool IsApproved { get; set; }
        public DateTime? ApprovalDate { get; set; }
    }
}
