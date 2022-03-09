using Shared.Entities;

namespace Shared.Interfaces;
public interface IStudentRepository:ISearch
{
    List<Student> GetStudents();
    void CreateStudent(Student s);
    Student GetStudent(int studentId);
    void DeleteStudent(int studentId);
    void UpdateStudent(int studentId, string attribute, string value);

}