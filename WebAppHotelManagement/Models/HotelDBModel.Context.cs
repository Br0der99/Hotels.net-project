﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAppHotelManagement.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HotelDBEntities : DbContext
    {
        public HotelDBEntities()
            : base("name=HotelDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<RoomBookings> RoomBookings { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }
        public virtual DbSet<BookingStatus> BookingStatus { get; set; }
        public virtual DbSet<PaymentTypes> PaymentTypes { get; set; }
        public virtual DbSet<RoomTypes> RoomTypes { get; set; }
    }
}
