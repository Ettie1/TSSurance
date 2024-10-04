using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TSSurance.Models
{
    public class RegAgent: Agent
    {
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Values do not match.")]
        public string ConfirmPassword { get; set; }
    }
}