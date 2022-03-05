// See https://aka.ms/new-console-template for more information

using System.Threading.Channels;
using Assignment3.Entity;
public class Program
{
    public static void Main(string[] args)
    {
        List<Vehicle> vehicles = new List<Vehicle>()
        {
            new Car("xyz", "BMW", 2020, 12, 30),
            new Motorcycle("kbh", "Cub", 1995, 7, 20),
            new Truck("GHJ", "Toyota",2019, 150, 10)
        };

        //distances each vehicle can go with the current level of fuel
        vehicles.AsParallel().Select(v => v.DistanceCalculate(100)).ForAll(d =>Console.WriteLine(d+" miles"));
        
        //Fuel need for each vehicle to reach 780 km 
        int distance = 780;
        double distanceInMiles = distance * 0.621371;
        vehicles.AsParallel().Select(v=>v.FuelCalculate(distanceInMiles)).ForAll(d=>Console.WriteLine(d+" gallon"));
    }
}