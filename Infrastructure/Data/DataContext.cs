using Npgsql;

namespace Infrastructure.Data;

public class DataContext
{
     const string connnectionstring = "Server=localhost;  Database=yalla; Username=postgres; Password=america2025";

     public NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(connnectionstring);
    }
}
