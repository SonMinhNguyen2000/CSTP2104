using Assignment1.Enum;
using Assignment1.Interface;
namespace Assignment1.Entity
{
    public class Truck: Car
    {
        TruckTypes _type;
        public Truck(string model, string brand, int year, int price, int mileage, Engines engine, TruckTypes type)
            :base(model,brand,year,price, mileage, engine)
        {
            _type = type;
        }

        public void setType(TruckTypes t) { this._type = t;}
        public string getType()
        {
            switch(_type)
            {
                case TruckTypes.Ambulance:
                    return "Ambulance";
                case TruckTypes.FireTruck:
                    return "fire truck";
                case TruckTypes.CarTransporter:
                    return "car transporter";
                case TruckTypes.Pickup:
                    return "pickup";
                default:
                    return "truck";
            }
        }

        public override string ToString()
        {
            return base.ToString() + String.Format("Truck type:{0}", getType());
        }
    }
}
