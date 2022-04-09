using Shared.Entities;
using testLayer.Mock;

namespace testLayer.Test;

public static class StudentRegistrationTest
{
    public static void GetAllStudentsTest(MockStudentRegistrationManager studentRegistrationManagerTool)
    {
        List<Student> students = studentRegistrationManagerTool.GetRegisteredStudents();
        foreach (var student in students)
        {
            Console.WriteLine("===================");
            Console.WriteLine(student.ToString());
        }
    }

    public static void RegisterStudentTest(MockStudentRegistrationManager studentRegistrationManagerTool)
    {
        Console.WriteLine("Test adding new student");
        Console.WriteLine("Enter student Id");
        var id = Console.ReadLine();
        Console.WriteLine("Enter student name");
        var name = Console.ReadLine();
        Console.WriteLine("Enter program id");
        var programId = Console.ReadLine();
        Student newStudent = new Student(id, name, programId);
        studentRegistrationManagerTool.RegisterStudent(newStudent);
    }

    public static void updateStudentTest(MockStudentRegistrationManager studentRegistrationManagerTool)
    {
        Console.WriteLine("\n//Test update student");
        Console.WriteLine("Enter student Id:");
        string studentId = Console.ReadLine();
        Console.WriteLine("Enter attribute to update");
        string attribute = Console.ReadLine();
        Console.WriteLine("Enter update value");
        string value = Console.ReadLine();
        studentRegistrationManagerTool.UpdateStudent(studentId, attribute, value);
        foreach (var registeredStudent in studentRegistrationManagerTool.GetRegisteredStudents())
        {
            Console.WriteLine($"id:{registeredStudent.GetId()} Name:{registeredStudent.Name}");
        }
    }

    public static void deleteStudentTest(MockStudentRegistrationManager studentRegistrationManagerTool)
    {
        Console.WriteLine("\n//Test delete student");
        Console.WriteLine("Enter student id");
        var id = Console.ReadLine();
        studentRegistrationManagerTool.DeleteStudent(id);
        foreach (var registeredStudent in studentRegistrationManagerTool.GetRegisteredStudents())
        {
            Console.WriteLine($"id:{registeredStudent.GetId()} Name:{registeredStudent.Name}");
        }
    }
}