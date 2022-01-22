using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsAppLib.OOD
{
    public class CustomCalculator : ICalculator
    {
        public int Calculate(int x)
        {
            return ((x * x) + 8) / 2;
        }
    }
}