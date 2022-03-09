namespace BusinessLogic;
using Shared.Entities;
using Shared.Interfaces;
public class StudentRegistrationManager
{
    private readonly IStudentRepository _studentRepository;

    public StudentRegistrationManager(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    
    public List<Student> GetRegisteredStudents()
    {
        var students = _studentRepository.GetStudents();
        return students;
    }

    public List<Student> GetStudentByName(string name)
    {
        return _studentRepository.SearchStudentByName(name);
    }

    public void UpdateStudent(int studentId, string attribute, string value)
    {
        _studentRepository.UpdateStudent(studentId, attribute, value);
    }

    public void DeleteStudent(int studentId)
    {
        _studentRepository.DeleteStudent(studentId);
    }

    public void AddNewStudent(Student s)
    {
        _studentRepository.CreateStudent(s);
    }
}