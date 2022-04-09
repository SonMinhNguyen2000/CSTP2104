// See https://aka.ms/new-console-template for more information

using BusinessLogic;
using DataAccessLayer;
using MySql.Data.MySqlClient;
using Shared.Entities;
using testLayer.Mock;
using testLayer.Test;

public class Program
{
    static void Main(string[] args)
    {
        var repo = new StudentRepository()
        {
            _dataService = new DataBaseService("127.0.0.1", "root", "test", 3306, "root")
        };
        repo._dataService.RunTestScript("../../../MockData/data.sql");
        MockStudentRegistrationManager studentRegistrationManagerTool = new MockStudentRegistrationManager(repo);
        
        StudentRegistrationTest.GetAllStudentsTest(studentRegistrationManagerTool);
        StudentRegistrationTest.updateStudentTest(studentRegistrationManagerTool);
        StudentRegistrationTest.deleteStudentTest(studentRegistrationManagerTool);
         
        
    }

    
    
    
}


