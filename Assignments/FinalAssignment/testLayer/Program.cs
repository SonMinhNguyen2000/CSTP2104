// See https://aka.ms/new-console-template for more information

using BusinessLogic;
using DataAccessLayer;
using MySql.Data.MySqlClient;
using Shared.Entities;

public class Program
{
    static void Main(string[] args)
    {
        var repo = new StudentRepository()
        {
            _dataService = new DataBaseService("127.0.0.1", "root", "test", 3306, "root")
        };
        repo._dataService.RunTestScript("../../../MockData/data.sql");
        StudentRegistrationManager managerTool = new StudentRegistrationManager(repo);

        #region test add student
        Console.WriteLine("//test add new student function");
        managerTool.AddNewStudent(new Student("3","Jack Cao","2"));
        managerTool.AddNewStudent(new Student("4","Jack Nguyen","2"));
        
        foreach (var registeredStudent in managerTool.GetRegisteredStudents())
        {
            Console.WriteLine($"id:{registeredStudent.GetId()} Name:{registeredStudent.Name}");
        }
        #endregion

        #region Test Search by name
        Console.WriteLine("\n//test search by name --Jack");
        foreach (var registeredStudent in managerTool.GetStudentByName("Jack"))
        {
            Console.WriteLine($"id:{registeredStudent.GetId()} Name:{registeredStudent.Name}");
        }
        #endregion

        #region test update student
        Console.WriteLine("\n//Test update student");
        managerTool.UpdateStudent(1, "Name", "Jackson Peri");
        foreach (var registeredStudent in managerTool.GetRegisteredStudents())
        {
            Console.WriteLine($"id:{registeredStudent.GetId()} Name:{registeredStudent.Name}");
        }
        #endregion

        #region test delete student
        Console.WriteLine("\n//Test delete student");
        managerTool.DeleteStudent(3);
        foreach (var registeredStudent in managerTool.GetRegisteredStudents())
        {
           Console.WriteLine($"id:{registeredStudent.GetId()} Name:{registeredStudent.Name}");
        }
        #endregion
        
    }
}