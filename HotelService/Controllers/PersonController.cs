using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Model;

namespace HotelService.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersons()
        {
            var users = await _personService.FindAllPersons();
            return Ok(users);
        }
    }
}