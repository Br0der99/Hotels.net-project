using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppHotelManagement.Models;
using WebAppHotelManagement.ViewModel;

namespace WebAppHotelManagement.Controllers
{
    public class BookingController : Controller
    {
        private HildurDatabaseEntities objHotelDBEntities;
        public BookingController()
        {
            objHotelDBEntities = new HildurDatabaseEntities();
        }

        public ActionResult Index()
        {
            BookingViewModel objBookingViewModel = new BookingViewModel();
            objBookingViewModel.ListOfRoom = (from objRoom in objHotelDBEntities.rooms
                                              where objRoom.bookingStatusId == 2
                                              select new SelectListItem()
                                              {
                                                  Text = objRoom.roomNumber,
                                                  Value = objRoom.id.ToString()
                                              }
                                              ).ToList();
            objBookingViewModel.BookingFrom = DateTime.Now;
            objBookingViewModel.BookingTo = DateTime.Now.AddDays(1);

            return View(objBookingViewModel);
        }
        [HttpPost]
        public ActionResult Index(BookingViewModel objBookingViewModel)
        {
            int numberOfDays = Convert.ToInt32((objBookingViewModel.BookingTo - objBookingViewModel.BookingFrom).TotalDays);
            rooms objRoom = objHotelDBEntities.rooms.Single(model => model.id == objBookingViewModel.AssignRoomId);
            decimal RoomPrice = objRoom.roomPrice;
            decimal TotalAmount = RoomPrice * numberOfDays;

            string dt = objBookingViewModel.BookingTo.ToString(format: "MM/dd/yyyy");
            booking roomBookings = new booking()
            {
                //  BookingId = objBookingViewModel.BookingId,
                roomId = objBookingViewModel.AssignRoomId,
                customerName = objBookingViewModel.CustomerName,
                customerAddress = objBookingViewModel.CustomerAddress,
                customerPhone = objBookingViewModel.CustomerPhone,
                bookingFrom = objBookingViewModel.BookingFrom,
                bookingTo = objBookingViewModel.BookingTo,
                noOfMembers = objBookingViewModel.NumberOfMembers,
                totalAmount = TotalAmount
            };
            objHotelDBEntities.booking.Add(roomBookings);
            objHotelDBEntities.SaveChanges();

            objRoom.bookingStatusId = 3;
            objHotelDBEntities.SaveChanges();

            return Json(new { message = "Hotel Booking is Successfully Created.", success = true }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public PartialViewResult GetAllBookingHistory()
        {
            List<RoomBookingViewModel> listOfBookingViewModels = new List<RoomBookingViewModel>();
            listOfBookingViewModels = (from objHotelBooking in objHotelDBEntities.booking
                                       join objRoom in objHotelDBEntities.rooms on objHotelBooking.roomId equals objRoom.id
                                       select new RoomBookingViewModel()
                                       {
                                           BookingFrom = objHotelBooking.bookingFrom,
                                           BookingTo = objHotelBooking.bookingTo,
                                           CustomerPhone = objHotelBooking.customerPhone,
                                           CustomerName = objHotelBooking.customerName,
                                           TotalAmount = objHotelBooking.totalAmount,
                                           CustomerAddress = objHotelBooking.customerAddress,
                                           NumberOfMembers = objHotelBooking.noOfMembers,
                                           BookingId = objHotelBooking.id,
                                           RoomNumber = objRoom.roomNumber,
                                           RoomPrice = objRoom.roomPrice,
                                           NumberOfDays = System.Data.Entity.DbFunctions.DiffDays(objHotelBooking.bookingFrom, objHotelBooking.bookingTo).Value

                                       }).ToList();
            return PartialView("_BookingHistoryPartial", listOfBookingViewModels);
        }
    }
}