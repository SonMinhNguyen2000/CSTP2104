namespace Shared.Entities;

public class Program
{
    public string Name { get; }
    public string Id { get; }

    public Program(string n, string id)
    {
        Name = n;
        Id = id;
    }
}