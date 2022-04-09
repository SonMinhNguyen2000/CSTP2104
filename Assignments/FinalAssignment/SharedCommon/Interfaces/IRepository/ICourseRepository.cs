using Shared.Entities;

namespace Shared.Interfaces;

public interface ICourseRepository
{
    List<Course> GetCourses();
    List<Course> GetCourses(string courseId);
}
