using Shared.Interfaces;

namespace Shared.Entities.StudentFilter;

public class StudentIDSpecification: ISpecification<Student>
{
    private readonly string _id;

    public StudentIDSpecification(string id)
    {
        _id = id;
    }

    public bool isSatisfied(Student t)
    {
        return t.GetId() == _id;
    }
}