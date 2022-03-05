using Assignment3.Enums;
using Assignment3.Interfaces;

namespace Assignment3.Entity;

public abstract class Vehicle:IDistanceCalculator, IFuelCalculator, IFuelLevelCalculator
{
    protected string Model { get; set; }
    
    protected string Brand { get; set; }
    protected int Year { get; set; }
    
    //gallon
    protected double FuelCapacity { get; set; }

    //mpg<miles per gallon>
    protected double FuelConsumption { get; set; }

    public new virtual string ToString()
    {
        return $"model: {Model}--year: {Year}--fuel capacity {FuelCapacity} gallon--fuel consumption:{FuelConsumption} mpg";
    }

    public abstract double DistanceCalculate(double milesDriven);

    public abstract double FuelCalculate(double distance);

    public abstract string FuelLevel(double milesDriven);

}