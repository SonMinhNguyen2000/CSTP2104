namespace Assignment4.Entities;

public class ProgramCourse
{
    public int ProgramId;
    public int CourseId;
    public bool Required;

    public ProgramCourse(int pid, int cid, bool r)
    {
        ProgramId = pid;
        CourseId = cid;
        Required = r;
    }
}