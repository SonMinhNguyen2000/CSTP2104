using MySql.Data.MySqlClient;
using Shared.Entities;

namespace DataAccessLayer;
using Shared.Interfaces;


public class StudentRepository : IStudentRepository
{
    public IDataService _dataService { get; set; }
    
    
    public List<Student> GetStudents()
    {
        List<Student> students = new List<Student>();
        _dataService.Query("select * from student");
        var reader = _dataService.Execute();
        while (reader.Read())
        {
            students.Add(new Student(
                reader["Id"].ToString(),
                reader["Name"].ToString(),
                reader["ProgramId"].ToString()
                )
            );
        }
        reader.Close();
        return students;
    }

    public void CreateStudent(Student s)
    {
        _dataService.Query("insert into student(FirstName, LastName, ProgramId) values (@n, @pid)");
        _dataService.Bind("@n", s.Name);
        _dataService.Bind("@pid", s.ProgramId);
        _dataService.Execute();
    }

    public Student GetStudent(int studentId)
    {
        _dataService.Query("Select * from student where Id=@sid");
        _dataService.Bind("@sid", studentId.ToString());
        var reader = _dataService.Execute();
        return new Student(
            reader["Id"].ToString(),
            reader["Name"].ToString(),
            reader["ProgramId"].ToString()
        );
    }

    public void DeleteStudent(int studentId)
    {
        _dataService.Query("delete from student where Id=@sid");
        _dataService.Bind("@sid", studentId.ToString());
        _dataService.Execute();
    }

    public void UpdateStudent(int studentId, string attibute, string value)
    {
        _dataService.Query($"update student set {attibute}=value where Id=@sid");
        _dataService.Bind("@sid", studentId.ToString());
        _dataService.Execute();
    }

    public List<Student> SearchStudentByName(string name)
    {
        List<Student> students = new List<Student>();
        _dataService.Query("select * from student where Name like @n ");
        _dataService.Bind("@n","%"+name+"%");
        var reader = _dataService.Execute();
        while (reader.Read())
        {
            students.Add(new Student(
                    reader["Id"].ToString(),
                    reader["Name"].ToString(),
                    reader["ProgramId"].ToString()
                )
            );
        }
        reader.Close();
        return students;
    }
}