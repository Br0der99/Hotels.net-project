using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess;
using Model;

namespace HotelService.Services
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetAllRooms();
    }
    
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        
        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        
        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            return await _roomRepository.GetAllRooms();
        }
    }
}