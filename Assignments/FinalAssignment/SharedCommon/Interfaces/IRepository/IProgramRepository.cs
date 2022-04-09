using Shared.Entities;

namespace Shared.Interfaces;

public interface IProgramRepository
{
    Program? getProgram(string programId);
    List<Course> getProgramCourses(string programId);
}