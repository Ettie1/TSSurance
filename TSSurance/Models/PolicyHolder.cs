using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TSSurance.Models
{
    public class PolicyHolder
    {
        [Key]
        public int PolicyHolderId { get; set; }

        public string Title { get; set; }

        //[Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        //[Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Display(Name = "ID Number")]
        public string IDNo { get; set; }

        //[Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        //[Required]
        [StringLength(200)]
        public string Address { get; set; }

        //[Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        //[Required]
        [StringLength(100)]
        public string Email { get; set; }

        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public virtual ICollection<Policy> Policies { get; set; }
        public string Salt { get; set; }
    }
}
