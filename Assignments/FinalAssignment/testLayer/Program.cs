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
        //To test this project on your desktop, you need to:
        DataBaseService dataSource = new DataBaseService(
            "127.0.0.1", //alter this with your db server
            "root", //alter this with your username
            "000433430CSTP2104TestingProject", //alter this with your database name
            3306, //alter this with you port number
            "root" //alter this with your password
            );
        dataSource.RunTestScript("../../../MockData/data.sql");//add mock data to db
        
        //initialize mock repositories
        MockStudentRepository studentRepo = new MockStudentRepository(dataSource);
        MockCourseRepository courseRepo = new MockCourseRepository(dataSource);
        MockProgramRepository programRepo = new MockProgramRepository(dataSource, courseRepo);
        
        //initialize mock managers
        MockCourseEnrollmentManager enrollRepo = new MockCourseEnrollmentManager(courseRepo, studentRepo, programRepo);
        CourseEnrollmentManagerTest.getSuggestedCourseTest(enrollRepo);
    }

}