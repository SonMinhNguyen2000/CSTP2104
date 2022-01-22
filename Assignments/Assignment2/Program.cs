// See https://aka.ms/new-console-template for more information


using Assignment2.Interfaces;

namespace Assignment2;
using Entities;
class Program
{
    public static void Main(string[] args)
    {
        Vehicle[] vehicles = new Vehicle[]
        {
            new Car(){MilesDriven = 60,FuelCapacity = 300},
            new Motocycle(){MilesDriven = 15, FuelCapacity = 150},
            new Truck(){MilesDriven = 60, FuelCapacity = 1000}
        };
        //Test listing distance base on vehicle list 
        double[] distances = distanceList(vehicles, new Vehicle());
        Console.Write("[");
        foreach(double distance in distances) Console.Write($"[{distance} miles],");
        Console.Write("]");
        //Test extension methods
        Console.WriteLine("\nVehicle need repaired? {0}", vehicles[0].isRepairNeeded(false)?"Yes":"No");
        
    }
    
    //return a list of distance base on the vehicle list
    static double[] distanceList(Vehicle[] vehicles, IDistanceCalculator calculator)
    {
        double[] result = new double[vehicles.Length];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = calculator.calculateDistance(vehicles[i].MilesDriven, vehicles[i].FuelCapacity);
        }
        return result;
    }
}

//extension method
public static class VehicleGarage
{
    public static bool isRepairNeeded(this Vehicle v, bool isBroken)
    {
        return isBroken;
    }
}