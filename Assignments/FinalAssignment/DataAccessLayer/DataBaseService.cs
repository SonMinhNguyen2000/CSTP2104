using MySql.Data.MySqlClient;
using Shared.Interfaces;

namespace DataAccessLayer;

public class DataBaseService:IDataService
{
    private static MySqlConnection _connection;
    private static MySqlCommand _command;
    public DataBaseService(string server, string user, string db, int port, string pwd)
    {
        _connection = new MySqlConnection($"server={server};user={user};database={db};port={port.ToString()};password={pwd}");
        _command = _connection.CreateCommand();
        _connection.Open();
    }

    public void Query(string query)
    {
        _command.CommandText = query;
    }

    public void Bind(string key, string value)
    {
        _command.Parameters.AddWithValue(key, value);
    }

    public void ClearQuery()
    {
        _command.Parameters.Clear();
    }

    public MySqlDataReader Execute()
    {
       return _command.ExecuteReader();
    }

    public void RunTestScript(string filepath)
    {
        MySqlScript script = new MySqlScript(_connection, File.ReadAllText(filepath));
        script.Execute();
    }
    
    public void Close()
    {
        _connection.Close();
    }
}