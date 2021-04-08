using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace DataAccess
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> FindAllUsers();
    }
}