using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsAppLib.OOD
{
    public class Squarer : ICalculator
    {
        public int Calculate(int x)
        {
            return x * x;
        }
    }
}