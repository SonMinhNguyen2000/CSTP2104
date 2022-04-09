using Shared.Entities;
using Shared.Interfaces;

namespace testLayer.Mock;

public class MockProgramRepository: IProgramRepository
{
    public readonly  IDataService DataService;
    public readonly ICourseRepository CourseRepo;
    
    public MockProgramRepository(IDataService dataSource, ICourseRepository courseRepo)
    {
        DataService = dataSource;
        CourseRepo = courseRepo;
    }
    
    public Program? getProgram(string programId)
    {
        DataService.Query("select * from program where ProgramId = @pid");
        DataService.Bind("@pid", programId);
        var reader = DataService.Execute();
        if (reader.Read())
        {
            Program programById = new Program(reader["Name"].ToString(), reader["ProgramId"].ToString());
            DataService.ClearQuery();
            reader.Close();
            return programById;
        }
        DataService.ClearQuery();
        reader.Close();
        return null;
    }

    public List<Course> getProgramCourses(string programId)
    {
        return getCoursesFromId(
            getProgramCoursesId(programId)
        );
    }

    public List<string> getProgramCoursesId(string programId)
    {
        List<string> coursesIds = new List<string>();
        DataService.Query("Select CourseId from programCourse where ProgramId = @pid");
        DataService.Bind("@pid", programId);
        var reader = DataService.Execute();
        while (reader.Read())
        {
            coursesIds.Add(reader["CourseId"].ToString());
        }
        DataService.ClearQuery();
        reader.Close();
        return coursesIds;
    }

    public List<Course> getCoursesFromId(List<String> coursesId)
    {
        List<Course> programCourses = new List<Course>();
        foreach (var id in coursesId)
        {
            Course? course = CourseRepo.GetCourse(id);
            if ( course != null)
            {
                programCourses.Add(course);
            }
        }
        return programCourses;
    }
}