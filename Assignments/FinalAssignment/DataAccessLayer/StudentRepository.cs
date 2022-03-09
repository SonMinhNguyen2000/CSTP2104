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
        _dataService.Query("insert into student(Id, Name, ProgramId) values (@id, @n, @pid)");
        _dataService.Bind("@id", s.GetId());
        _dataService.Bind("@n", s.Name);
        _dataService.Bind("@pid", s.ProgramId);
        var reader = _dataService.Execute();
        _dataService.ClearQuery();
        reader.Close();
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
        var reader = _dataService.Execute();
        _dataService.ClearQuery();
        reader.Close();
    }

    public void UpdateStudent(int studentId, string attribute, string value)
    {
        _dataService.Query($"update student set {attribute}=@value where Id=@sid");
        _dataService.Bind("@sid", studentId.ToString());
        _dataService.Bind("@value", value);
        var reader =_dataService.Execute();
        _dataService.ClearQuery();
        reader.Close();
    }

    public List<Student> SearchStudentByName(string name)
    {
        List<Student> students = new List<Student>();
        _dataService.Query("select * from student where Name like @n ");
        _dataService.Bind("@n","%"+name+"%");
        var reader = _dataService.Execute();
        _dataService.ClearQuery();
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