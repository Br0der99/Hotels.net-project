using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppHotelManagement.ViewModel
{
    public class BookingViewModel
    {
        //   public int BookingId { get; set; }
        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "Customer name is required.")]
        public string CustomerName { get; set; }

        [Display(Name = "Customer Address")]
        [Required(ErrorMessage = "Customer Address is required.")]
        public string CustomerAddress { get; set; }

        [Display(Name = "Customer Phone")]
        [Required(ErrorMessage = "Customer Phone is required.")]
        public string CustomerPhone { get; set; }
        //DateTime skal være Date uden Time for at fremvise en kalender. Men så er outputtet yyyy-MM-dd vidst standard pga noget US. Og det fungere ikke som EU.
        [Display(Name = "Booking From")]
        [Required(ErrorMessage = "Booking From is required.")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.Date)]
        public DateTime BookingFrom { get; set; }

        //DateTime skal være Date uden Time for at fremvise en kalender. Men så er outputtet yyyy-MM-dd vidst standard pga noget US. Og det fungere ikke som EU.
        [Display(Name = "Booking To")]
        [Required(ErrorMessage = "Booking To is required.")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.Date)]
        public DateTime BookingTo { get; set; }

        [Display(Name = "Assign Room")]
        [Required(ErrorMessage = "Room is required.")]
        public int AssignRoomId { get; set; }

        [Display(Name = "Number Of Members")]
        [Required(ErrorMessage = "Number of members is required.")]
        public int NumberOfMembers { get; set; }
        public IEnumerable<SelectListItem> ListOfRoom { get; set; }
    }
}