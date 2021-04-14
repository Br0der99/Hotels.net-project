using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace DataAccess
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> FindAllPersons();
    }
}