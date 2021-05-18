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
                var query = @"SELECT *, bs.bookingStatus AS BookingStatusName
                    FROM rooms r
                    JOIN roomTypes rt on rt.roomTypeId = r.roomTypeId
                    JOIN bookingStatus bs on bs.bookingStatusId = r.bookingStatusId";
                return await conn.QueryAsync<Room, RoomType, BookingStatus, Room>(query, 
                    (room, roomType, bookingStatus) =>
                    {
                        room.BookingStatus = bookingStatus;
                        room.RoomType = roomType;
                        return room;
                    }, splitOn: "RoomTypeId,bookingStatusId");
            });
        }

        public async Task<Room> GetRoomById(int id)
        {
            return await WithConnection(async conn =>
            {
                var query = @"SELECT TOP 1 *, bs.bookingStatus AS BookingStatusName
                    FROM rooms r
                    JOIN roomTypes rt on rt.roomTypeId = r.roomTypeId
                    JOIN bookingStatus bs on bs.bookingStatusId = r.bookingStatusId
                    WHERE r.roomId = @Id";
                var result = await conn.QueryAsync<Room, RoomType, BookingStatus, Room>(query, 
                (room, roomType, bookingStatus) =>
                    {
                        room.BookingStatus = bookingStatus;
                        room.RoomType = roomType;
                        return room;
                    }, new
                    {
                        Id = id
                    }, splitOn: "RoomTypeId,bookingStatusId");
                return result.FirstOrDefault();
            });
        }

        public async Task AddRoom(Room room)
        {
            await WithConnection(async conn =>
            {
                var query = @"
                    Insert Into Rooms(roomNumber, roomImage, roomPrice, bookingStatusId, roomTypeId, roomCapacity, roomDescription, isActive)
                    VALUES (@RoomNumber, @RoomImage, @RoomPrice, @BookingStatusId, @RoomTypeId, @RoomCapacity, @RoomDescription, @IsActive);
                    SELECT CAST(SCOPE_IDENTITY() as int)";

                var id = await conn.QuerySingleOrDefaultAsync<int>(query, new
                {
                    RoomNumber = room.RoomNumber,
                    RoomImage = room.RoomImage,
                    RoomPrice = room.RoomPrice,
                    BookingStatusId = room.BookingStatus.BookingStatusId,
                    RoomTypeId = room.RoomType.RoomTypeId,
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
                var query = "DELETE FROM Rooms WHERE roomId = @Id";
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
                    SET roomNumber = @RoomNumber,
                        roomImage = @RoomImage,
                        roomPrice = @RoomPrice,
                        bookingStatusId = @BookingStatusId,
                        roomTypeId = @RoomTypeId,
                        roomCapacity = @RoomCapacity,
                        roomDescription = @RoomDescription,
                        isActive = @IsActive
                    WHERE roomId = @Id";
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