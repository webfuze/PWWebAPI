﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PWDataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PubWorksEntities : DbContext
    {
        public PubWorksEntities()
            : base("name=PubWorksEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<csc> csc { get; set; }
        public virtual DbSet<cscRez> cscRez { get; set; }
        public virtual DbSet<cscStatus> cscStatus { get; set; }
        public virtual DbSet<cscType> cscType { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
    }
}
