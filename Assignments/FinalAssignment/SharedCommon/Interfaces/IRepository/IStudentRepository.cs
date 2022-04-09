using Shared.Entities;

namespace Shared.Interfaces;
public interface IStudentRepository
{
    List<Student> GetStudents();
    List<Student> GetFilteredStudent(IFilter<Student> filter, ISpecification<Student> spec);
    void CreateStudent(Student s);
    void DeleteStudent(string studentId);
    void UpdateStudent(string studentId, string attribute, string value);
}