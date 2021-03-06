// See https://aka.ms/new-console-template for more information

using System.Data;
using Assignment4.DBMS;
using Assignment4.Entities;
public class Program
{
    static void Main(string[] args)
    {
        DatabaseService dbService = new DatabaseService();
        
        //student table
        dbService.Query(
            "create table Students(Name VARCHAR(50), ID INTEGER, StreetAddress VARCHAR(100), City VARCHAR(50), Province VARCHAR(50), Country VARCHAR(50), PostalCode VARCHAR(6), Email VARCHAR(100), PhoneNumber INTEGER, ProgramID INTEGER)");
        dbService.Execute();
        dbService.Query(
            "insert into Students(Name, ID, StreetAddress, City, Province, Country, PostalCode, Email, PhoneNumber, ProgramID) values (@name, @id, @address, @city, @province, @country, @pc, @email, @pn, @pid)");
        List<Student> students = new List<Student>()
        {
            new Student("Jackson Peri", 1, "123 West Pender", "Vancouver", "BC", "Canada", "V2R6R5", "jack@vcc.ca", "4567821912", 1),
            new Student("John King", 1, "123 West Pender", "Vancouver", "BC", "Canada", "V2R6R6", "john@vcc.ca", "4567851912", 2),
            new Student("Jim Pratt", 1, "123 West Pender", "Vancouver", "BC", "Canada", "V2R6R67", "Jim@vcc.ca", "4567841912", 3),
        };
        foreach (Student s in students)
        {
            dbService.Bind("@name", s.Name);
            dbService.Bind("@id", s.Id.ToString());
            dbService.Bind("@address", s.StreetAddress);
            dbService.Bind("@city", s.City);
            dbService.Bind("@province", s.Province);
            dbService.Bind("@country", s.Country);
            dbService.Bind("@pc", s.PostalCode);
            dbService.Bind("@email", s.Email);
            dbService.Bind("@pn", s.PhoneNumber);
            dbService.Bind("@pid", s.ProgramId.ToString());
            dbService.Execute();
            dbService.ClearQuery();
        }
        dbService.PrintAll("Students");
        
        //course table 
        dbService.Query("create table Courses(ID INTEGER, Name VARCHAR(10), Description VARCHAR(500), Credit INTEGER)");
        dbService.Execute();
        dbService.Query("insert into Courses(ID, Name, Description, Credit) values(@id, @n, @d, @c)");
        List<Course> courses = new List<Course>()
        {
            new Course(1, "Algebra", "Math class", 3),
            new Course(2, "Window dev", "Progamming course", 3),
            new Course(3, "Dart dev","Programming course", 3)
        };
        foreach (Course c in courses)
        {
            dbService.Bind("@id", c.Id.ToString());
            dbService.Bind("@n", c.Name);
            dbService.Bind("@d", c.Description);
            dbService.Bind("@c", c.Credit.ToString());
            dbService.Execute();
            dbService.ClearQuery();
        }
        dbService.PrintAll("Courses");
        
        //Program table
        dbService.Query("create table Programs(ID INTEGER , Name VARCHAR(10), Description VARCHAR(500))");
        dbService.Execute();
        dbService.Query("insert into Programs(ID, Name, Description) values(@id, @n, @d)");
        List<Assignment4.Entities.Program> programs = new List<Assignment4.Entities.Program>()
        {
            new Assignment4.Entities.Program(1, "Computer Science", "software developing program"),
            new Assignment4.Entities.Program(2, "Hospitality", "Hotel and serving"),
            new Assignment4.Entities.Program(3, "Finance", "Banking and Finance management")
        };
        foreach (var p in programs)
        {
            dbService.Bind("@id", p.Id.ToString());
            dbService.Bind("@n", p.Name);
            dbService.Bind("@d", p.Description);
            dbService.Execute();
            dbService.ClearQuery();
        }
        dbService.PrintAll("Programs");
        
        //ProgramCourse table
        dbService.Query("create table ProgramCourse(ProgramID INTEGER, CourseID INTEGER, Required INTEGER )");
        dbService.Execute();
        dbService.Query("insert into ProgramCourse(ProgramID, CourseID, Required) values (@pid, @cid, @r)");
        List<ProgramCourse> programsCourses = new List<ProgramCourse>()
        {
            new ProgramCourse(1, 2, true),
            new ProgramCourse(1, 3, true),
            new ProgramCourse(2, 1, false)
        };
        foreach (var pc in programsCourses)
        {
            dbService.Bind("@pid", pc.ProgramId.ToString());
            dbService.Bind("@cid", pc.CourseId.ToString());
            dbService.Bind("@r", (pc.Required?1:0).ToString());
            dbService.Execute();
            dbService.ClearQuery();
        }
        dbService.PrintAll("ProgramCourse");
        dbService.Close();
    }
    
}

