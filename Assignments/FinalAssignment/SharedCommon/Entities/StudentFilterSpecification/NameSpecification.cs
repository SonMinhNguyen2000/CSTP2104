using Shared.Interfaces;

namespace Shared.Entities.StudentFilter;

public class NameSpecification:ISpecification<Student>
{
    private readonly string _name;

    public NameSpecification(string name)
    {
        _name = name;
    }

    public bool isSatisfied(Student t)
    {
        return t.Name == _name;
    }
}