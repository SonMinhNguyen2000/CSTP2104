using System.Text;
using Microsoft.Data.Sqlite;

namespace WindowsAppLib.DBMS;

public class AdoNetExample
{
    //connection strings for Microsoft SQL
    //string connString = "Server=myServer;Database=myDatabase; User Id=myUserId; Password=yPassword";
    //string connString = "Server=myServer; Database=myDatabase; Trusted_Connection=True";
    //string connString = "DataSource=.;Initial Catalog=master;Integrated Security=True";
    //string connString = "DataSource=.\SQLEXPRESS;Initial Catalog=master; Integrated Security=True";
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

    public List<string> GetStudents()
    {
        var studentRecords = new List<String>();
        var stringBuilder = new StringBuilder();
        try
        {
            using (var connection = OpenConnection())
            {
                connection.Open();
                var commandText = "select * from students";
                using (var command = new SqliteCommand(commandText, connection))
                {
                    command.CommandText = commandText;
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        stringBuilder.AppendLine("=============");
                        stringBuilder.AppendLine(reader[0].ToString());
                        stringBuilder.AppendLine(reader[1].ToString());
                        stringBuilder.AppendLine(reader[2].ToString());
                        stringBuilder.AppendLine(reader[3].ToString());
                        studentRecords.Add(stringBuilder.ToString());
                        stringBuilder.Clear();
                    }                
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception is thrown: {0}", e.Message);
            throw;
        }

        return studentRecords;
    }

}