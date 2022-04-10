using Shared.Entities;
using Shared.Entities.StudentFilter;
using testLayer.Mock;

namespace testLayer.Test;

public static class CourseEnrollmentManagerTest
{
    public static void getSuggestedCourseTest(MockCourseEnrollmentManager mockRepo)
    {
        Filter<Student> filter = new Filter<Student>();
        Console.WriteLine("==========Test case 1==========");
        StudentIDSpecification idSpec2 = new StudentIDSpecification("2");
        Student student2 = mockRepo.StudentRepo.GetFilteredStudent(filter, idSpec2)[0];
        Console.WriteLine("Student info");
        Console.WriteLine(student2.ToString());
        var program2 = mockRepo.ProgramRepo.getProgram(student2.ProgramId);
        Console.WriteLine($"Program: {program2.Name}");
        Console.WriteLine("=======Courses student has passed========");
        var passedCourses2 = mockRepo.GetPassedCourses(mockRepo.CourseRepo.GetStudentCourses("2"));
        foreach (var passedCourse in passedCourses2)
        {
            Console.WriteLine($"{passedCourse.ToString()}, ");
        }
        Console.WriteLine("=======Suggested course for next term=========");
        List<Course> suggestedCourse2 =  mockRepo.GetSuggestCourse("2");
        foreach (var course in suggestedCourse2)
        {
            Console.WriteLine(course.ToString());
        }
        
        Console.WriteLine("\n==========Test case 2==========");
        StudentIDSpecification idSpec = new StudentIDSpecification("1");
        Student student1 = mockRepo.StudentRepo.GetFilteredStudent(filter, idSpec)[0];
        Console.WriteLine("Student info");
        Console.WriteLine(student1.ToString());
        var program = mockRepo.ProgramRepo.getProgram(student1.ProgramId);
        Console.WriteLine($"Program: {program.Name}");
        Console.WriteLine("=======Courses student has passed========");
        var passedCourses = mockRepo.GetPassedCourses(mockRepo.CourseRepo.GetStudentCourses("1"));
        foreach (var passedCourse in passedCourses)
        {
            Console.WriteLine($"{passedCourse.ToString()}, ");
        }
        Console.WriteLine("=======Suggested course for next term=========");
        List<Course> suggestedCourse =  mockRepo.GetSuggestCourse("1");
        foreach (var course in suggestedCourse)
        {
            Console.WriteLine(course.ToString());
        }
    }
}