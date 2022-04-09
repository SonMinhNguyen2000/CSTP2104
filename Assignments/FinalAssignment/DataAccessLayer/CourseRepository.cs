using Google.Protobuf.WellKnownTypes;
using Shared.Entities;
using Shared.Interfaces;

namespace DataAccessLayer;

public class CourseRepository: ICourseRepository
{
    public IDataService _dataService { get; set; }
    
    public List<Course> GetCourses()
    {
        List<Course> courses = new List<Course>();
        _dataService.Query("select * from course");
        var reader = _dataService.Execute();
        while (reader.Read())
        {
            courses.Add(new Course(
                    reader["CourseId"].ToString(),
                    reader["Name"].ToString(),
                    reader["Description"].ToString()
                )
            );
        }
        reader.Close();
        return courses;
    }

    public List<Course> GetCourses(string courseId)
    {
        throw new NotImplementedException();
    }

    public List<Course> GetFilterCourse(IFilter<Course> filter, ISpecification<Course> spec)
    {
        return filter.Filtering(GetCourses(), spec);
    }
}