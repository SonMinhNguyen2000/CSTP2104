using Shared.Interfaces;

namespace Shared.Entities.StudentFilter;

public class ProgramIDSpecification: ISpecification<Student>
{
    private readonly string _programID;

    public ProgramIDSpecification(string programId)
    {
        _programID = programId;
    }

    public bool isSatisfied(Student t)
    {
        return t.ProgramId == _programID;
    }
    
}