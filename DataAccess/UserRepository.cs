using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Queries;
using Microsoft.Extensions.Configuration;
using Model;
using Dapper;

namespace DataAccess
{
    public class PersonRepository : BaseRepository, IPersonRepository
    {
        private readonly ICommandText _commandText;
        
        public PersonRepository(IConfiguration configuration, ICommandText commandText) : base(configuration)
        {
            _commandText = commandText;
        }
        
        public async Task<IEnumerable<Person>> FindAllPersons()
        {
            return await WithConnection(async con =>
            {
                return await con.QueryAsync<Person>(_commandText.FindAllUsers);
            });
        }
    }
}