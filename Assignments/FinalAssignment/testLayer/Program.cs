// See https://aka.ms/new-console-template for more information
using DataAccessLayer;
using MySql.Data.MySqlClient;

public class Program
{
    static void Main(string[] args)
    {
        StudentRepository sr = new StudentRepository()
        {
            _dataService = new DataBaseService("127.0.0.1", "root", "test", 3306, "root")
        };
        sr._dataService.RunTestScript("../../../MockData/data.sql");
        foreach (var student in sr.SearchStudentByName("Cao"))
        {
            Console.WriteLine($"Id:{student.GetId()} Name:{student.Name} pid:{student.ProgramId}");
        }
    }
}