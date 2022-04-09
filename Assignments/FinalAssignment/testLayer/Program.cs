// See https://aka.ms/new-console-template for more information

using DataAccessLayer;
using testLayer.Mock;
using testLayer.Test;

namespace testLayer;

public static class Program
{
    static void Main(string[] args)
    {
        RunAllTest();
    }

    private static void RunAllTest()
    {
        DataBaseService dataSource = new DataBaseService("127.0.0.1", "root", "test", 3306, "root");
        dataSource.RunTestScript("../../../MockData/data.sql");
        
        //initialize mock repositories
        StudentRepository studentRepo = new StudentRepository(dataSource);
        MockCourseRepository courseRepo = new MockCourseRepository(dataSource);
        ProgramRepository programRepo = new ProgramRepository(dataSource, courseRepo);
        
        //initialize mock managers
        MockCourseEnrollmentManager enrollRepo = new MockCourseEnrollmentManager(courseRepo, studentRepo, programRepo);
        CourseEnrollmentManagerTest.getSuggestedCourseTest(enrollRepo);
    }

}