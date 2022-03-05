using SharedCommon.Entities;

namespace DataAccessLayer;
using SharedCommon.Interfaces;

public class StudentRepository : IStudentRepository
{
    public List<Student> GetStudents()
    {
        return new List<Student>();
    }

}