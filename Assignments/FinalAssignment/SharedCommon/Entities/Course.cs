namespace Shared.Entities;

public class Course
{
    public string CourseID { get; }
    public string CourseName { get; }
    public string CourseDescription { get; }
    
    public string PreRequisiteId { get; }
    
    public Course(string id, string name, string description)
    {
        CourseID = id;
        CourseName = name;
        CourseDescription = description;
    }
}