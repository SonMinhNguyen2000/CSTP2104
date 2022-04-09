using System.Dynamic;
using System.Text;

namespace Shared.Entities;

public class Student
{
    private string _id;
    public string Name;
    public string? ProgramId;

    public Student(string id, string n, string programId)
    {
        _id = id;
        Name = n;
        ProgramId = programId;
    }

    public string GetId()
    {
        return _id;
    }

    public override string ToString()
    {
        return $"student id: {_id}\nstudent name: {Name}\nProgram Id: {ProgramId}";
    }
}