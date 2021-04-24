using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Model;
using Microsoft.Extensions.Configuration;
using HotelService.BusinessLogiclayer;
using Model;

namespace HotelService.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public RoomController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet, Route("rooms")]
        public ActionResult<List<Room>> Get()
        {
            RoomControl roomCtrl = new RoomControl(_configuration);
            List<Room> foundRooms = roomCtrl.GetAllRooms();
            if (foundRooms != null)
            {
                if (foundRooms.Count >= 1)
                {
                    return Ok(foundRooms);
                }
            }
            return NotFound();
        }

        /**
                // GET: RoomController
                public ActionResult Index()
                {
                    return View();
                }

                // GET: RoomController/Details/5
                public ActionResult Details(int id)
                {
                    return View();
                }

                // GET: RoomController/Create
                public ActionResult Create()
                {
                    return View();
                }

                // POST: RoomController/Create
                [HttpPost]
                [ValidateAntiForgeryToken]
                public ActionResult Create(IFormCollection collection)
                {
                    try
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    catch
                    {
                        return View();
                    }
                }

                // GET: RoomController/Edit/5
                public ActionResult Edit(int id)
                {
                    return View();
                }

                // POST: RoomController/Edit/5
                [HttpPost]
                [ValidateAntiForgeryToken]
                public ActionResult Edit(int id, IFormCollection collection)
                {
                    try
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    catch
                    {
                        return View();
                    }
                }

                // GET: RoomController/Delete/5
                public ActionResult Delete(int id)
                {
                    return View();
                }

                // POST: RoomController/Delete/5
                [HttpPost]
                [ValidateAntiForgeryToken]
                public ActionResult Delete(int id, IFormCollection collection)
                {
                    try
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    catch
                    {
                        return View();
                    }
                }
            }
            **/
    }
}
