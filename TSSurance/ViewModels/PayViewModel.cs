using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TSSurance.Models;

namespace TSSurance.ViewModels
{
    public class PayViewModel
    {
        public PolicyHolder Policyholder { get; set; }
        public Payment Payment { get; set; }

    }
}