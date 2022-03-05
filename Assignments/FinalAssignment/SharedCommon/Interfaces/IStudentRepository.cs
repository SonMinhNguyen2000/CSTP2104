using SharedCommon.Entities;

namespace SharedCommon.Interfaces;
using SharedCommon.Entities;
public interface IStudentRepository
{
    List<Student> GetStudents();
}