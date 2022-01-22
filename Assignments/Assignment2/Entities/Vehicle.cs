namespace Assignment2.Entities;
using Enums;
using Interfaces;
public class Vehicle:IDistanceCalculator
{
    public string Model;
    public Makes Make;
    public int Year;
    public Engines Engine;
    //fuel level
    public double MilesDriven;
    public double FuelCapacity;

    public virtual int GetMaxSpeed()
    {
        return 0;
    }
    
    public double calculateDistance(double milesDriven, double fuelCapacity)
    {
        double mpg = milesDriven / fuelCapacity;
        return mpg;
    }
}