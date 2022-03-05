namespace Assignment4.Entities;

public class Course
{
    public int Id;
    public string Name;
    public string Description;
    public int Credit;

    public Course(int id, string n, string d, int c)
    {
        Id = id;
        Name = n;
        Description = d;
        Credit = c;
    }
}