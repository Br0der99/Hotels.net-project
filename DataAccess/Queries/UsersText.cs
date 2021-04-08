namespace DataAccess.Queries
{
    public partial class CommandText : ICommandText
    {
        public string FindAllUsers => "Select * From Users";
        
    }
}