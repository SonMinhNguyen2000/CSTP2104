using Google.Protobuf.WellKnownTypes;
using Shared.Entities;
using Shared.Interfaces;

namespace DataAccessLayer;

public class CourseRepository: ICourseRepository
{
    public IDataService DataService { get;  }
    public IPrerequisite PreRepository { get; }

    public CourseRepository(IDataService dataSource, IPrerequisite preRepo)
    {
        DataService = dataSource;
        PreRepository = preRepo;
    }
    
    public List<Course> GetCourses()
    {
        List<Course> courses = new List<Course>();
        DataService.Query("select * from course");
        var reader = DataService.Execute();
        while (reader.Read())
        {
            courses.Add(new Course(
                    reader["CourseId"].ToString(),
                    reader["Name"].ToString(),
                    reader["Description"].ToString(),
                    bool.Parse(reader["hasPrerequisite"].ToString())
                )
            );
        }
        DataService.ClearQuery();
        reader.Close();
        return courses;
    }

    public Course? GetCourse(string courseId)
    {
        Course course;
        DataService.Query("select * from course where CourseId = @cid");
        DataService.Bind("@cid", courseId);
        var reader = DataService.Execute();
        if (reader.Read())
        {
            course = new Course(
                reader["CourseId"].ToString(),
                reader["Name"].ToString(),
                reader["Description"].ToString(),
                bool.Parse(reader["hasPrerequisite"].ToString())
            );
            DataService.ClearQuery();
            reader.Close();
            return course;
        }
        DataService.ClearQuery();
        reader.Close();
        return null;
    }

    public List<Course> GetFilteredCourse(IFilter<Course> filter, ISpecification<Course> spec)
    {
        return filter.Filtering(GetCourses(), spec);
    }

    public List<List<Course>>? getPrerequisite(string id)
    {
        //step 1: check if course have any prerequisite
        //prerequisite groups of the course - group represents "or" relationship
        //Ex: list[group1, group2, group3] -> this means group1 or group2 or group 3 can be prerequisite of 1 course
        List<string> prerequisiteGroups = PreRepository.getPrerequisiteGroupId(id);
        if (prerequisiteGroups.Count == 0)
        {
            return null;
        }
        
        //step 2: get courseIds from prerequisite groups
        //prerequisite ids of each prerequisite group - inside of each group represent "and" relationship
        //Ex: list[[id1, id2], [id3,id4], [id5,id6,id7]]
        List<List<String>> prerequisiteIds = new List<List<string>>();
        foreach (var prerequisiteGroup in prerequisiteGroups) 
        {
            prerequisiteIds.Add(PreRepository.getPrerequisiteId(prerequisiteGroup));
        }

        //step 3: get prerequisite courses base on the courseIds
        //prerequisite of the course
        //Ex: list[[course1, course2], [course3, course4], [course5, course6, course7]]
        List<List<Course>> prerequisites = new List<List<Course>>(); 
        foreach (var prerequisiteId in prerequisiteIds) //step 3: 
        {
            List<Course> prerequisite = new List<Course>();
            foreach (var preId in prerequisiteId)
            {
                prerequisite.Add(GetCourse(preId));
            }
            prerequisites.Add(prerequisite);
        }
        return prerequisites;
    }

    public List<(string, double)> GetStudentCoursesIdAndGrade(string studentId)
    {
        List<(string, double)> coursesIdsAndGrade = new List<(string, double)>();
        DataService.Query("select * from studentCourses where StudentId=@sid");
        DataService.Bind("@sid", studentId);
        var reader = DataService.Execute();
        while (reader.Read())
        {
            string courseId = reader["CourseId"].ToString();
            double grade = double.Parse(reader["Grade"].ToString());
            coursesIdsAndGrade.Add((courseId, grade));
        }
        DataService.ClearQuery();
        reader.Close();
        return coursesIdsAndGrade;
    }

    public List<(Course, double)> GetStudentCoursesAndGrade(string studentId)
    {
        List<(Course, double)> coursesAndGrade = new List<(Course, double)>();
        foreach (var id in GetStudentCoursesIdAndGrade(studentId))
        {
            Course course = GetCourse(id.Item1);
            coursesAndGrade.Add((course, id.Item2));
        }
        return coursesAndGrade;
    }
}


