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
}