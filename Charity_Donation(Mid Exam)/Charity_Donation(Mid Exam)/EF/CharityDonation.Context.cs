﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Charity_Donation_Mid_Exam_.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Charity_DonationEntities : DbContext
    {
        public Charity_DonationEntities()
            : base("name=Charity_DonationEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CampainInfo> CampainInfoes { get; set; }
        public virtual DbSet<Donation> Donations { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
