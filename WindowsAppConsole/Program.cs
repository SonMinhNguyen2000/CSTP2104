using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using WindowsAppLib.OOD;
using System.Threading;
using WindowsAppLib.DBMS;
using WindowsAppLib.MultiThread;

namespace WindowsAppConsole
{
    class Program
    {
        //Thread, multi-threading
        //concurrency,
        //

        
        static void Main(string[] args)
        {
            //Week2Examples();
            //Week3Examples();
            Week4Examples();
        }

        static void Week4Examples()
        {
            var adonetexample = new AdoNetExample();
            adonetexample.CreateAndAddRow();
        }

        static void Week3Examples()
        {
            try
            {
                // var threadRun = new ThreadExample();
                // threadRun.RunAThread();

                var taskRun = new TaskExamples();
                // taskRun.RunTask();
                // taskRun.RunTask2();
                // taskRun.RunTask3();
                // taskRun.RunTask4();
                taskRun.RunAsParallel2();
            }
            catch (Exception e)
            {
                Console.WriteLine($"exception throw: {e.Message}");
            }
        }
        
        static void Week2Examples()
        {
            Console.WriteLine("Hello World!");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to Windows Application Development !");
            Console.BackgroundColor = ConsoleColor.Black;

            Car car = new Car()
            {
                Engine = Engines.Cylinder_4,
                Make = Makes.BMW,
                Year = 2021,
                Model = "X3"
            };

            Car car2 = new Car()
            {
                Engine = Engines.Cylinder_4,
                Make = Makes.Toyota,
                Year = 2020,
                Model = "Corola"
            };

            Program.Display1(car);
            Program.Display1(car2);

            Vehicle v = car; // upcast
            Car car3 = (Car)v; // downcast

            var m = new Motorcycle();
            Vehicle vt = m;
            // Car car4 = (Car)vt;  // run-time error InvalidCastException

            // as operator
            // is operator 

            var values = new int[] { 2, 4, 5, 8 };
            var result = Program.Calculate(values, new Squarer());
            Program.Display(result);

            result = Program.Calculate(values, new Cuber());
            Program.Display(result);

            result = Program.Calculate(values, new CustomCalculator());
            Program.Display(result);

            string s = "123";
            var isCapitalized = s.IsCapitalized();
            Console.WriteLine($"{s} IsCapitalized:{isCapitalized}");
            
            s = "Ace";
            isCapitalized = s.IsCapitalized();
            Console.WriteLine($"{s} IsCapitalized:{isCapitalized}");

            s = "base";
            isCapitalized = s.IsCapitalized();
            Console.WriteLine($"{s} IsCapitalized:{isCapitalized}");

            s = "";
            isCapitalized = s.IsCapitalized();
            Console.WriteLine($"{s} IsCapitalized:{isCapitalized}");

            s = null;
            isCapitalized = s.IsCapitalized();
            Console.WriteLine($"{s} IsCapitalized:{isCapitalized}");
            int x = 2;
        }
        
        static int[] Calculate(int[] values, ICalculator calculator)
        {
            int[] result = new int[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                var r = calculator.Calculate(values[i]);
                result[i] = r;
            }

            return result;
        }

        static void Display(int[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                Console.WriteLine($"i={i} {values[i]}");
            }
        }

        static void Display1(Vehicle vehicle)
        {
            Console.WriteLine(vehicle.Make);
            Console.WriteLine(vehicle.Model);
            Console.WriteLine(vehicle.Year);
        }

        public static void Display2(Truck truck)
        {

        }
    }

    public static class StringHelper
    {
        // Extension method
        public static bool IsCapitalized(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return false;
            }

            return char.IsUpper(s[0]);
        }

        public static bool isMax(this int i)
        {
            return i > 10;
        }
    }
}
