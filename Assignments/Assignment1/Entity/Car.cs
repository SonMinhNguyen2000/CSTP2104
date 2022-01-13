﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.Enum;

namespace Assignment1.Entity
{
    public class Car : Vehicle
    {
        public Car(string m, string b, int y, int p, Engines e):base(m, b, y, p, e)
        {
            this.setVehicleType(VehicleType.FourWheel);
        }
    }
}
