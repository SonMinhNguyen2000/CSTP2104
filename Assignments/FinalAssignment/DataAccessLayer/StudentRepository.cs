using MySql.Data.MySqlClient;
using Shared.Entities;

namespace DataAccessLayer;
using Shared.Interfaces;


public class StudentRepository : IStudentRepository
{
    public IDataService DataService { get; set; }

    public StudentRepository(IDataService dataSource)
    {
        DataService = dataSource;
    }

    public List<Student> GetStudents() 
    {
        List<Student> students = new List<Student>();
        DataService.Query("select * from student");
        var reader = DataService.Execute();
        while (reader.Read())
        {
            students.Add(new Student(
                reader["Id"].ToString(),
                reader["Name"].ToString(),
                reader["ProgramId"].ToString()
                )
            );
        }
        DataService.ClearQuery();
        reader.Close();
        return students;
    }

    public void CreateStudent(Student s)
    {
        DataService.Query("insert into student(Id, Name, ProgramId) values (@id, @n, @pid)");
        DataService.Bind("@id", s.GetId());
        DataService.Bind("@n", s.Name);
        DataService.Bind("@pid", s.ProgramId);
        var reader = DataService.Execute();
        DataService.ClearQuery();
        reader.Close();
    }

    public void DeleteStudent(string studentId)
    {
        DataService.Query("delete from student where Id=@sid");
        DataService.Bind("@sid", studentId.ToString());
        var reader = DataService.Execute();
        DataService.ClearQuery();
        reader.Close();
    }

    public void UpdateStudent(string studentId, string attribute, string value)
    {
        DataService.Query($"update student set {attribute}=@value where Id=@sid");
        DataService.Bind("@sid", studentId.ToString());
        DataService.Bind("@value", value);
        var reader =DataService.Execute();
        DataService.ClearQuery();
        reader.Close();
    }

    public List<Student> GetFilteredStudent(IFilter<Student> filter, ISpecification<Student> spec )
    {
        return filter.Filtering(GetStudents(), spec);
    }

}