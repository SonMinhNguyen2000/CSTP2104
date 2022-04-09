using Shared.Interfaces;

namespace Shared.Entities.CourseFilterSpecification;

public class HasPrerequisiteSpecification: ISpecification<Course>
{
    private readonly bool _hasPrerequisite;

    public HasPrerequisiteSpecification(bool hasPrerequisite)
    {
        _hasPrerequisite = hasPrerequisite;
    }

    public bool isSatisfied(Course c)
    {
        return c.hasPrerequisite == _hasPrerequisite;
    }
}