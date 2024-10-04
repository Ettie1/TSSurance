using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TSSurance.Models;

namespace TSSurance.ViewModels
{
    public class AddPolicyViewModel
    {
        public PolicyHolder Policyholder { get; set; }
        public Policy Policy { get; set; }

    }
}