using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Model;

namespace DataAccess
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllRooms();
        Task<Room> GetRoomById(int id);
        Task AddRoom(Room room);
        Task<bool> DeleteRoom(int id);
        Task<bool> UpdateRoom(Room room);
    }

    public class RoomRepository : BaseRepository, IRoomRepository
    {
        public RoomRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            return await WithConnection(async conn =>
            {
                var query = @"SELECT *
                    FROM Rooms r
                    JOIN RoomTypes rt on rt.Id = r.RoomTypeId";
                return await conn.QueryAsync<Room, RoomType, Room>(query, (room, roomType) =>
                {
                    room.RoomType = roomType;
                    return room;
                }, splitOn: "RoomTypeId");
            });
        }

        public async Task<Room> GetRoomById(int id)
        {
            return await WithConnection(async conn =>
            {
                var query = @"SELECT TOP 1 *
                    FROM Rooms r
                    JOIN RoomTypes rt on rt.Id = r.RoomTypeId
                    WHERE r.Id = @Id";
                var result = await conn.QueryAsync<Room, RoomType, Room>(query, (room, roomType) =>
                {
                    room.RoomType = roomType;
                    return room;
                }, new
                {
                    Id = id
                }, splitOn: "RoomTypeId");
                return result.FirstOrDefault();
            });
        }

        public async Task AddRoom(Room room)
        {
            await WithConnection(async conn =>
            {
                var query = @"
                    Insert Into Rooms(NumberOfBeds, Price, RoomTypeId)
                    VALUES (@NumberOfBeds, @Price, @RoomTypeId);
                    SELECT CAST(SCOPE_IDENTITY() as int)";
                var id = await conn.QuerySingleOrDefaultAsync<int>(query, new
                {
                    RoomNumber = room.RoomNumber,
                    RoomImage = room.RoomImage,
                    RoomPrice = room.RoomPrice,
                    BookingStatusId = room.BookingStatus,
                    RoomTypeId = room.RoomType,
                    RoomCapacity = room.RoomCapacity,
                    RoomDescription = room.RoomDescription,
                    IsActive = true

                });
                room.RoomId = id;
            });
        }

        public async Task<bool> DeleteRoom(int id)
        {
            return await WithConnection(async conn =>
            {
                var query = "DELETE FROM Rooms WHERE Id = @Id";
                var deletedRows = await conn.ExecuteAsync(query, new
                {
                    Id = id
                });
                return deletedRows > 0;
            });
        }

        public async Task<bool> UpdateRoom(Room room)
        {
            return await WithConnection(async conn =>
            {
                var query = @"
                    UPDATE Rooms
                    SET NumberOfBeds = @NumberOfBeds,
                        Price = @Price,
                        RoomTypeId = @RoomTypeId
                    WHERE Id = @Id";
                var updatedRows = await conn.ExecuteAsync(query, new
                {
                    Id = room.RoomId,
                    RoomNumber = room.RoomNumber,
                    RoomImage = room.RoomImage,
                    RoomPrice = room.RoomPrice,
                    BookingStatusId = room.BookingStatus,
                    RoomTypeId = room.RoomType,
                    RoomCapacity = room.RoomCapacity,
                    RoomDescription = room.RoomDescription,
                    IsActive = true
                });
                return updatedRows > 0;
            });
        }
    }
}