using Shared.Entities;
using Shared.Interfaces;

namespace testLayer.Mock;

public class MockStudentRegistrationManager
{
    private readonly IStudentRepository _studentRepository;

    public MockStudentRegistrationManager(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    
    public List<Student> GetRegisteredStudents()
    {
        var students = _studentRepository.GetStudents();
        return students;
    }

    public List<Student> GetFilteredStudents(IFilter<Student> filter, ISpecification<Student> spec)
    {
        return _studentRepository.GetFilteredStudent(filter, spec);
    }

    public void UpdateStudent(string studentId, string attribute, string value)
    {
        _studentRepository.UpdateStudent(studentId, attribute, value);
    }
    
    public void DeleteStudent(string studentId)
    {
        _studentRepository.DeleteStudent(studentId);
    }

    public void RegisterStudent(Student s)
    {
        _studentRepository.CreateStudent(s);
    }
}