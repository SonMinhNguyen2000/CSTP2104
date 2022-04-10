using Shared.Entities;
using Shared.Entities.CourseFilterSpecification;
using Shared.Entities.StudentFilter;
using Shared.Interfaces;

namespace testLayer.Mock;

public class MockCourseEnrollmentManager
{
    public ICourseRepository CourseRepo;
    public IStudentRepository StudentRepo;
    public IProgramRepository ProgramRepo;

    public MockCourseEnrollmentManager(
        ICourseRepository cRepo, 
        IStudentRepository sRepo, 
        IProgramRepository pRepo)
    {
        CourseRepo = cRepo;
        StudentRepo = sRepo;
        ProgramRepo = pRepo;
    }

    public void EnrollStudent(string studentId, string courseId, string semesterId)
    {
        
    }

    public List<Course>? GetSuggestCourse(string studentId)
    {
        var student = getStudentById(studentId);
        if (student != null)//student exist?
        {
            List<Course> suggestedCourses = new List<Course>();
        
            //courses student has taken 
            List<(Course, double)> studentsCourses = CourseRepo.GetStudentCoursesAndGrade(studentId);
            if (studentsCourses.Count == 0) //student hasn't taken any course (new student)
            {
                suggestedCourses = getCoursesWithNoPrerequisite();//suggest course with no prerequisite
            }
            else
            {
                List<Course> passedCourse = GetPassedCourses(studentsCourses);
                List<Course> programCourses = getProgramCourses(student.ProgramId);
                List<Course> remainingCourses = getRemainingCourses(passedCourse, programCourses);
                foreach (var remainingCourse in remainingCourses)
                {
                    if (!remainingCourse.hasPrerequisite)
                    {
                        suggestedCourses.Add(remainingCourse);
                    }
                    else
                    {
                        List<List<Course>>? coursePrerequisites = CourseRepo.getPrerequisite(remainingCourse.CourseID);//
                        foreach (var coursePrerequisite in coursePrerequisites)
                        {
                            bool hasPassedPrerequisite = true;
                            for (var i = 0; i < coursePrerequisite.Count; i++)
                            {
                                if (!passedCourse.Exists(c=>c.CourseID==coursePrerequisite[i].CourseID))
                                {
                                    hasPassedPrerequisite = false;
                                }
                            }
                            if (hasPassedPrerequisite) suggestedCourses.Add(remainingCourse);
                        }
                    }
                }
            }
            return suggestedCourses;
        }

        return null;
    }

    private List<Course> getCoursesWithNoPrerequisite()
    {
        Filter<Course> filter = new Filter<Course>();
        
        HasPrerequisiteSpecification noPrerequisiteSpec = new HasPrerequisiteSpecification(false);
  
        return CourseRepo.GetFilteredCourse(filter, noPrerequisiteSpec);
    }

    public List<Course> GetPassedCourses(List<(Course, double)> studentCourses)
    {
        List<Course> passedCourse = new List<Course>(); 
        
        foreach (var studentCourse in studentCourses)
        {
            if (studentCourse.Item2 >= 60) 
            {
                passedCourse.Add(studentCourse.Item1);
            }
        }
        return passedCourse;
    }
    
    private List<Course> getProgramCourses(string programId)
    {
        return ProgramRepo.getProgramCourses(programId);
    }

    //get courses student hasn't taken yet
    private List<Course> getRemainingCourses(List<Course> passedCourses, List<Course> programCourses)
    {
        List<Course> coursesLeft = new List<Course>();
        foreach (var course in programCourses)
        {
            if(!passedCourses.Exists(c => c.CourseID == course.CourseID)) 
                coursesLeft.Add(course);

        }
        return coursesLeft;
    }

    private Student? getStudentById(string id)
    {
        Filter<Student> filter = new Filter<Student>();
        StudentIDSpecification idSpecification = new StudentIDSpecification(id);
        List<Student> studentById = StudentRepo.GetFilteredStudent(filter, idSpecification);
        if (studentById.Count == 0)
        {
            return null;
        }
        return StudentRepo.GetFilteredStudent(filter, idSpecification)[0];
    }
}