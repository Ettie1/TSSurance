using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TSSurance.Models
{
    public class PolicyType
    {
        [Key]
        public int PolicyTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public virtual ICollection<Policy> Policies { get; set; }
    }
}
