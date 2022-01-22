using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsAppLib.OOD
{
    public class Car : Vehicle
    {
        public string Trim;
        public string BodyType;
        

        public decimal Kilometers;
        public decimal Price;

        public Car()
        {
            Engine = Engines.Cylinder_4;
        }

        public Car(string model)
        {
            this.Model = model;
        }
    }
}
