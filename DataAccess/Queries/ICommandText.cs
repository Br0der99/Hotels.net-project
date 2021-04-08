using System;

namespace DataAccess.Queries
{
    public interface ICommandText
    {
        string FindAllUsers { get; }
        string FindAllHotels { get; }
        
    }
}