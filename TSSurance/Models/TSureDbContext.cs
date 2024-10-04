using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TSSurance.Models
{
    public class TSureDbContext: DbContext
    {
        public TSureDbContext() : base("name=sureconn") { }
        public DbSet<PolicyHolder> PolicyHolders { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Beneficiary> Beneficiaries { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PolicyType> PolicyTypes { get; set; }

        public System.Data.Entity.DbSet<TSSurance.Models.RegAgent> RegAgents { get; set; }
    }
}