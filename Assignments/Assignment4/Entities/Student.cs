namespace Assignment4.Entities;

public class Student
{
    public string Name;
    public int Id;
    public string StreetAddress;
    public string City;
    public string Province;
    public string Country;
    public string PostalCode;
    public string Email;
    public string PhoneNumber;
    public int ProgramId;

    public Student(string name, int id, string ad, string c, string p, string co, string pc, string e, string pn,
        int pid)
    {
        Name = name;
        Id = id;
        StreetAddress = ad;
        City = c;
        Province = p;
        Country = co;
        PostalCode = pc;
        Email = e;
        PhoneNumber = pn;
        ProgramId = pid;
    }
    
}