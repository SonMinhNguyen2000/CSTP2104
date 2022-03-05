using Microsoft.Data.Sqlite;

namespace Assignment4.DBMS;

public class DatabaseService
{
    static SqliteConnection connection;
    static SqliteCommand command;

    public DatabaseService()
    {
        connection = new SqliteConnection();
        connection.Open();
        command = connection.CreateCommand();
    }
    
    public void Query(string query)
    {
        command.CommandText = query;
    }

    public void Bind(string parameter, string value)
    {
        command.Parameters.AddWithValue(parameter, value);
    }

    public void ClearQuery()
    {
        command.Parameters.Clear();
    }

    public void Execute()
    {
        command.ExecuteNonQuery();
    }

    public void PrintAll(string table)
    {
        Query($"select * from {table}");
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine("==========");
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.WriteLine(reader[i]);
            }
        }
        reader.Close();
    }

    public void Close()
    {
        connection.Close();
    }
}