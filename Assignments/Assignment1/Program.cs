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
            Vehicle vehicle = new Vehicle("2HKSDFHJ","Yamaha",2006, 12000,30000, Engines.OneCylinder);
            Console.WriteLine("=====test vehicle:=====\n"+vehicle);
            //test car:
            Car car1 = new Car("SDHFJAS", "Toyota", 2019, 20000, 300000,Engines.FourCylinder);
            Console.WriteLine("\n=====test car:======\n" + car1);
            //test truck:
            Truck truck1 = new Truck("DSJFAKSAD", "Hummer", 2020,
                30000,300000, Engines.FourCylinder,TruckTypes.Ambulance);
            Console.WriteLine("\n=====test truck:======\n" + truck1);
            //test Motorcycle:
            Motorcycle bike1 = new Motorcycle("ASDIOFH", "Yamaha", 2021, 
                10000,30000000, Engines.FourCylinder,MotorcycleTypes.Cruiser);
            Console.WriteLine("\n=====test motorcycle:======\n" + bike1);
        }
    }
}