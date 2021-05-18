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
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class HildurDatabaseEntities : DbContext
    {
        public HildurDatabaseEntities()
            : base("name=HildurDatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<booking> booking { get; set; }
        public virtual DbSet<bookingStatus> bookingStatus { get; set; }
        public virtual DbSet<rooms> rooms { get; set; }
        public virtual DbSet<roomTypes> roomTypes { get; set; }
    
        public virtual int RoomAddOrEdit(Nullable<int> roomId, string roomNumber, string roomImage, Nullable<int> roomPrice, Nullable<int> bookingStatusId, Nullable<int> roomTypeId, Nullable<int> roomCapacity, string roomDescription, Nullable<bool> isActive)
        {
            var roomIdParameter = roomId.HasValue ?
                new ObjectParameter("RoomId", roomId) :
                new ObjectParameter("RoomId", typeof(int));
    
            var roomNumberParameter = roomNumber != null ?
                new ObjectParameter("RoomNumber", roomNumber) :
                new ObjectParameter("RoomNumber", typeof(string));
    
            var roomImageParameter = roomImage != null ?
                new ObjectParameter("RoomImage", roomImage) :
                new ObjectParameter("RoomImage", typeof(string));
    
            var roomPriceParameter = roomPrice.HasValue ?
                new ObjectParameter("RoomPrice", roomPrice) :
                new ObjectParameter("RoomPrice", typeof(int));
    
            var bookingStatusIdParameter = bookingStatusId.HasValue ?
                new ObjectParameter("BookingStatusId", bookingStatusId) :
                new ObjectParameter("BookingStatusId", typeof(int));
    
            var roomTypeIdParameter = roomTypeId.HasValue ?
                new ObjectParameter("RoomTypeId", roomTypeId) :
                new ObjectParameter("RoomTypeId", typeof(int));
    
            var roomCapacityParameter = roomCapacity.HasValue ?
                new ObjectParameter("RoomCapacity", roomCapacity) :
                new ObjectParameter("RoomCapacity", typeof(int));
    
            var roomDescriptionParameter = roomDescription != null ?
                new ObjectParameter("RoomDescription", roomDescription) :
                new ObjectParameter("RoomDescription", typeof(string));
    
            var isActiveParameter = isActive.HasValue ?
                new ObjectParameter("IsActive", isActive) :
                new ObjectParameter("IsActive", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RoomAddOrEdit", roomIdParameter, roomNumberParameter, roomImageParameter, roomPriceParameter, bookingStatusIdParameter, roomTypeIdParameter, roomCapacityParameter, roomDescriptionParameter, isActiveParameter);
        }
    
        public virtual int RoomDeleteByID(Nullable<int> roomId)
        {
            var roomIdParameter = roomId.HasValue ?
                new ObjectParameter("RoomId", roomId) :
                new ObjectParameter("RoomId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RoomDeleteByID", roomIdParameter);
        }
    
        public virtual ObjectResult<RoomViewOrSearch_Result> RoomViewOrSearch(string searchText)
        {
            var searchTextParameter = searchText != null ?
                new ObjectParameter("SearchText", searchText) :
                new ObjectParameter("SearchText", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RoomViewOrSearch_Result>("RoomViewOrSearch", searchTextParameter);
        }
    }
}