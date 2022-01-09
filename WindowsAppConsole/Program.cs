using System;
using WindowsAppLib.OOD;


namespace WindowsAppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;

            Car car = new Car()
            {
                Engine = engines.four_cylinders,
                Brand = "Mercedes",
                Year = 2019
            };

            Car car2 = new Car()
            {
                Model = "2XYZ",
                Engine = engines.four_cylinders,
                Brand = "Merceds",
                //Year = 2021
            };
        }
    }
}
