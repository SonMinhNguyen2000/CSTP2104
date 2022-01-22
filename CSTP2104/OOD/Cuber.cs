using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsAppLib.OOD
{
    public class Cuber : ICalculator
    {
        public int Calculate(int x)
        {
            return x * x * x;
        }
    }
}