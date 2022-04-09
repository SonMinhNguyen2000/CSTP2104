using Shared.Entities;

namespace Shared.Interfaces;

public interface ICourseRepository
{
    List<Course> GetCourses();
    Course? GetCourse(string courseId);
    List<(Course, double)> GetStudentCourses(string studentID);
    List<Course> GetFilteredCourse(IFilter<Course> filter, ISpecification<Course> spec);
    List<List<Course>>? getPrerequisite(string id);
}
