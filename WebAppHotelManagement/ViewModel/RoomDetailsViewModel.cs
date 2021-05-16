using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppHotelManagement.ViewModel
{
    public class RoomDetailsViewModel
    {
        public int id { get; set; }
        public string roomNumber { get; set; }
        public string roomImage { get; set; }
        public decimal roomPrice { get; set; }
        public string bookingStatus { get; set; }
        public string roomType { get; set; }
        public int roomCapacity { get; set; }
        public string roomDescription { get; set; }
 


    }
}