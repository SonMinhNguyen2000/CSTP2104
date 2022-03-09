using Shared.Entities;

namespace Shared.Interfaces;

public interface ISearch
{
    List<Student> SearchStudentByName(string name);
}