using System.ComponentModel.DataAnnotations;

namespace TSSurance.Models
{
    public class Beneficiary
    {
        [Key]
        public int BeneficiaryId { get; set; }

        [Required]
        public int PolicyId { get; set; }
        public virtual Policy Policy { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Relationship { get; set; }

        [Required]
        [Range(0, 100)]
        public double AllocationPercentage { get; set; }
    }
}
