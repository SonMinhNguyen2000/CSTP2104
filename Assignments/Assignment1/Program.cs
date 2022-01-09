using System;
namespace Assignment1
{
    using Entity;
    using Enum;
    class Program
    {
        static void Main(string[] args)
        {
            //vehicle test:
            Vehicle vehicle = new Vehicle("2HKSDFHJ","Yamaha",2006, 12000);
            Console.WriteLine("=====test vehicle:=====\n"+vehicle.ToString());
            //test car:
            Car car1 = new Car("SDHFJAS", "Toyota", 2019, 20000);
            Console.WriteLine("\n=====test car:======\n" + car1.ToString());
            //test truck:
            Truck truck1 = new Truck("DSJFAKSAD", "Hummer", 2020, 30000, TruckType.ambulance);
            Console.WriteLine("\n=====test truck:======\n" + truck1.ToString());
            //test Motocycle:
            Motocycle bike1 = new Motocycle("ASDIOFH", "Yamaha", 2021, 10000, MotocycleType.cruiser);
            Console.WriteLine("\n=====test motocycle:======\n" + bike1.ToString());
        }
    }
}