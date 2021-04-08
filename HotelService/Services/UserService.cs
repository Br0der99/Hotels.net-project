using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess;
using Model;

namespace HotelService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async ValueTask<IEnumerable<User>> FindAllUsers()
        {
            return await _userRepository.FindAllUsers();
        }
    }
}