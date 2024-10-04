using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TSSurance.Models
{
    [Table("Address")]
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public int PolicyHolderId { get; set; }
        public string AddressType { get; set; }
        [DisplayName("Street / No")]
        public string Addr1 { get; set; }
        [Display(Name = "Suburb")]
        public string Addr2 { get; set; }
        [DisplayName("Town / City")]
        public string Addr3 { get; set; }
        [Display(Name = "Code")]
        public string Addr4 { get; set; }
        
    }
}