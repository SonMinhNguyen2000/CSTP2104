// See https://aka.ms/new-console-template for more information

using DataAccessLayer;
using testLayer.Mock;
using testLayer.Test;

namespace testLayer;

public static class TestLayer
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
        MockStudentRepository studentRepo = new MockStudentRepository(dataSource);
        MockCourseRepository courseRepo = new MockCourseRepository(dataSource);
        MockProgramRepository programRepo = new MockProgramRepository(dataSource, courseRepo);
        
        //initialize mock managers
        MockCourseEnrollmentManager enrollRepo = new MockCourseEnrollmentManager(courseRepo, studentRepo, programRepo);
        CourseEnrollmentManagerTest.getSuggestedCourseTest(enrollRepo);
    }

}