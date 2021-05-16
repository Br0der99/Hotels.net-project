using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppHotelManagement.Models;
using WebAppHotelManagement.ViewModel;

namespace WebAppHotelManagement.Controllers
{
    public class RoomController : Controller
    {
        private HildurDatabaseEntities objHotelDBEntities;
        public RoomController()
        {
            objHotelDBEntities = new HildurDatabaseEntities();

        }
        public ActionResult Index()
        {
            RoomViewModel objRoomViewModel = new RoomViewModel();
            objRoomViewModel.ListOfBookingStatus = (from obj in objHotelDBEntities.bookingStatus
                                                    select new SelectListItem()
                                                    {
                                                        Text = obj.bookingStatus1,
                                                        Value = obj.id.ToString()
                                                    }).ToList();

            objRoomViewModel.ListOfRoomType = (from obj in objHotelDBEntities.roomTypes
                                               select new SelectListItem()
                                               {
                                                   Text = obj.roomType,
                                                   Value = obj.id.ToString()
                                               }).ToList();

            return View(objRoomViewModel);
        }
        [HttpPost]
        public ActionResult Index(RoomViewModel objRoomViewModel)
        {
            string message = String.Empty;
            string ImageUniqueName = String.Empty;
            string ActualImageName = String.Empty;
            if (objRoomViewModel.RoomId == 0)
            {
                ImageUniqueName = Guid.NewGuid().ToString();
                ActualImageName = ImageUniqueName + Path.GetExtension(objRoomViewModel.Image.FileName);

                objRoomViewModel.Image.SaveAs(filename: Server.MapPath("~/RoomImages/" + ActualImageName));
                //objHotelDBEntities
                rooms objRoom = new rooms()
                {
                    roomNumber = objRoomViewModel.RoomNumber,
                    roomDescription = objRoomViewModel.RoomDescription,
                    roomPrice = objRoomViewModel.RoomPrice,
                    bookingStatusId = objRoomViewModel.BookingStatusId,
                    isActive = true,
                    roomImage = ActualImageName,
                    roomCapacity = objRoomViewModel.RoomCapacity,
                    roomTypeId = objRoomViewModel.RoomTypeId
                };
                objHotelDBEntities.rooms.Add(objRoom);
                message = "Added.";
            }
            else
            {
                rooms objRoom = objHotelDBEntities.rooms.Single(model => model.id == objRoomViewModel.RoomId);
                if (objRoomViewModel.Image != null)
                {
                    ImageUniqueName = Guid.NewGuid().ToString();
                    ActualImageName = ImageUniqueName + Path.GetExtension(objRoomViewModel.Image.FileName);
                    objRoomViewModel.Image.SaveAs(filename: Server.MapPath("~/RoomImages/" + ActualImageName));
                    objRoom.roomImage = ActualImageName;
                }


                objRoom.roomNumber = objRoomViewModel.RoomNumber;
                objRoom.roomDescription = objRoomViewModel.RoomDescription;
                objRoom.roomPrice = objRoomViewModel.RoomPrice;
                objRoom.bookingStatusId = objRoomViewModel.BookingStatusId;
                objRoom.isActive = true;
                objRoom.roomCapacity = objRoomViewModel.RoomCapacity;
                objRoom.roomTypeId = objRoomViewModel.RoomTypeId;
                message = "Updated.";
            }

            objHotelDBEntities.SaveChanges();

            return Json(new { message = "Room Successfully " + message, success = true }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetAllRooms()
        {
            IEnumerable<RoomDetailsViewModel> listOfRoomsDetailsViewModels =
                (from objRoom in objHotelDBEntities.rooms
                 join objBooking in objHotelDBEntities.bookingStatus on objRoom.id equals objBooking.id
                 join objRoomType in objHotelDBEntities.roomTypes on objRoom.id equals objRoomType.id
                 where objRoom.isActive == true
                 select new RoomDetailsViewModel()
                 {
                     roomNumber = objRoom.roomNumber,
                     roomDescription = objRoom.roomDescription,
                     roomCapacity = objRoom.roomCapacity,
                     roomPrice = objRoom.roomPrice,
                     bookingStatus = objBooking.bookingStatus1,
                     roomType = objRoomType.roomType,
                     roomImage = objRoom.roomImage,
                     id = objRoom.id
                 }).ToList();

            return PartialView("_RoomDetailsPartial", listOfRoomsDetailsViewModels);
           // return PartialView("~/Views/Shared/_RoomDetailsPartial.cshtml", listOfRoomsDetailsViewModels);
        }


        [HttpGet]
        public JsonResult EditRoomDetails(int roomId)
        {
            var result = objHotelDBEntities.rooms.Single(model => model.id == roomId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult DeleteRoomDetails(int roomId)
        {
            rooms objRoom = objHotelDBEntities.rooms.Single(model => model.id == roomId);
            objRoom.isActive = false;
            objHotelDBEntities.SaveChanges();
            return Json(new { message = "Record Successfully Deleted", success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}
