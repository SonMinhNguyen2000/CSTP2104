using Microsoft.Data.Sqlite;

namespace WindowsAppLib.DBMS;

public class AdoNetExample
{
    public SqliteConnection OpenConnection()
    {
        SqliteConnection connection = new SqliteConnection();
        return connection;
    }

    public void CreateAndAddRow()
    {
        var connection = OpenConnection();
        var command = connection.CreateCommand();
        command.CommandText =
            "create table students (name VARCHAR(50),email VARCHAR(50), address VARCHAR (100), id INTEGER)";
        connection.Open();
        command.ExecuteNonQuery();

        var insertCommand = connection.CreateCommand();
        insertCommand.CommandText =
            "insert into students (name, email, address, id) values (@name, @email, @address, @id)";
        insertCommand.Parameters.AddWithValue("@name", "Tom Brady");
        insertCommand.Parameters.AddWithValue("@email", "tombrady@vcc.ca");
        insertCommand.Parameters.AddWithValue("@address", "Breadway West Vancouver, BC");
        insertCommand.Parameters.AddWithValue("@id", "1023");
        int result = insertCommand.ExecuteNonQuery();
        
        insertCommand.Parameters.Clear();
        insertCommand.Parameters.AddWithValue("@name", "Julio");
        insertCommand.Parameters.AddWithValue("@email", "julio@vcc.ca");
        insertCommand.Parameters.AddWithValue("@address", "101 West BroadWay Vancouver, BC");
        insertCommand.Parameters.AddWithValue("@id", "1024");
        result = insertCommand.ExecuteNonQuery();
        
        var queryCommand = connection.CreateCommand();
        queryCommand.CommandText = "select * from students";
        var reader = queryCommand.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine("\n=========");
            Console.WriteLine(reader[0]);
            Console.WriteLine(reader[1]);
            Console.WriteLine(reader[2]);
            Console.WriteLine(reader[3]);
        }
        
        connection.Close();
    }

    public void Insert()
    {
        
    }

}