﻿namespace DataAccess.Queries
{
    public partial class CommandText : ICommandText
    {
        public string FindAllHotels => "Select * From Hotels";
    }
}