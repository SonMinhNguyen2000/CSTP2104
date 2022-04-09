namespace Shared.Entities;

public class Course
{
    public string CourseID { get; }
    public string CourseName { get; }
    public string CourseDescription { get; }
    
    public bool hasPrerequisite { get; }
    
    public Course(string id, string name, string description, bool hp)
    {
        CourseID = id;
        CourseName = name;
        CourseDescription = description;
        hasPrerequisite = hp;
    }

    public override string ToString()
    {
        return $"Course id: {CourseID} courseName: {CourseName}";
    }
}