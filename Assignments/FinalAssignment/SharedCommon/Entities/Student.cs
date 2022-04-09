using System.Dynamic;
using System.Text;

namespace Shared.Entities;

public class Student
{
    private string _id;
    public readonly string Name;
    public readonly string ProgramId;

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
        return $"student id: {_id}\nstudent name: {Name}\n";
    }
    
}