using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Model;

namespace DataAccess
{
    public interface IRoomTypeRepository
    {
        Task<IEnumerable<RoomType>> GetAllRoomTypes();
        Task AddRoomType(RoomType roomType);
        Task<bool> DeleteRoomType(int id);
    }
    
    
    public class RoomTypeRepository : BaseRepository, IRoomTypeRepository
    {
        public RoomTypeRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<RoomType>> GetAllRoomTypes()
        {
            return await WithConnection(async conn =>
            {
                var query = @"SELECT * FROM roomTypes";
                return await conn.QueryAsync<RoomType>(query);
            }); 
        }

        public async Task AddRoomType(RoomType roomType)
        {
            await WithConnection(async conn =>
            {
                var query = @"
                    Insert Into roomTypes(roomType)
                    VALUES (@RoomTypes);
                    SELECT CAST(SCOPE_IDENTITY() as int)";
                var id = await conn.QuerySingleOrDefaultAsync<int>(query, new
                {
                    RoomTypes = roomType.RoomTypes
                });
                roomType.Id = id;
            });
        }

        public async Task<bool> DeleteRoomType(int id)
        {
            return await WithConnection(async conn =>
            {
                var query = "DELETE FROM RoomTypes WHERE id = @Id";
                var deletedRows = await conn.ExecuteAsync(query, new
                {
                    Id = id
                });
                return deletedRows > 0;
            });
        }
    }
}