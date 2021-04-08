using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Queries;
using Microsoft.Extensions.Configuration;
using Model;
using Dapper;

namespace DataAccess
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly ICommandText _commandText;
        
        public UserRepository(IConfiguration configuration, ICommandText commandText) : base(configuration)
        {
            _commandText = commandText;
        }
        
        public async Task<IEnumerable<User>> FindAllUsers()
        {
            return await WithConnection(async con =>
            {
                return await con.QueryAsync<User>(_commandText.FindAllUsers);
            });
        }
    }
}