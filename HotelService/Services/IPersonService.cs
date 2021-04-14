using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace HotelService.Services
{
    public interface IPersonService
    {
        ValueTask<IEnumerable<Person>> FindAllPersons();
    }
}