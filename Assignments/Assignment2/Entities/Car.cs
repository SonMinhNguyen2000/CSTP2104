namespace Assignment2.Entities;
using Enums;
public class Car:Vehicle
{
    public string Trim;
    public string BodyType;
        

    public decimal Kilometers;
    public decimal Price;

    public Car()
    {
        Engine = Engines.Cylinder4;
    }

    public Car(string model)
    {
        this.Model = model;
    }
}