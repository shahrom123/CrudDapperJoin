using System.Data;
using Npgsql;

public class DapperContext
{
    string connectionString = "Server=localhost; Port=5432; Database=Dapper3Category; User Id=postgres; Password=233223;";

    public DapperContext()
    {
        
    }
    public IDbConnection CreateConnetion()
    {
        return  new NpgsqlConnection(connectionString) ;
    }
}



