using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelService.Services;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace HotelService.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.FindAllUsers();
            return Ok(users);
        }
    }
}