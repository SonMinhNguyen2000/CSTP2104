using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.Enum;
using Assignment1.Interface;
namespace Assignment1.Entity
{
    public class Truck: Car, IPrint
    {
        TruckType type;
        public Truck(string model, string brand, int year, int price, TruckType type):base(model,brand,year,price)
        {
            this.type = type;
        }

        public void setType(TruckType t) { this.type = t;}
        public string getType()
        {
            switch(this.type)
            {
                case TruckType.ambulance:
                    return "Ambulance";
                case TruckType.fire_truck:
                    return "fire truck";
                case TruckType.car_transporter:
                    return "car transporter";
                case TruckType.pickup:
                    return "pickup";
                default:
                    return "truck";
            }
        }

        override public string ToString()
        {
            return base.ToString() + String.Format("Truck type:{0}", this.getType());
        }
    }
}
