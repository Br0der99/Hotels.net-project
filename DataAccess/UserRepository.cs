using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Model;
using Dapper;

namespace DataAccess
{
    public class UserRepository : BaseRepository, IUserRepository
    {
       
        
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
            
        }
        
        public async Task<IEnumerable<User>> FindAllUsers()
        {
            return await WithConnection(async con =>
            {
                return await con.QueryAsync<User>("SELECT * FROM User");
            });
        }
    }
}