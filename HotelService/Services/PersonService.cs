using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess;
using Model;

namespace HotelService.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        
        public async ValueTask<IEnumerable<Person>> FindAllPersons()
        {
            return await _personRepository.FindAllPersons();
        }
    }
}