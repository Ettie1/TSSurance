using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TSSurance.Models
{
    public class Agent
    {
        [Key]
        public int AgentId { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Salt { get; set; }

        public virtual ICollection<Policy> PoliciesSold { get; set; }
    }
}
