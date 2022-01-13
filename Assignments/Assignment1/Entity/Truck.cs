using Assignment1.Enum;
using Assignment1.Interface;
namespace Assignment1.Entity
{
    public class Truck: Car, IPrint
    {
        TruckType _type;
        public Truck(string model, string brand, int year, int price, int me, Engines e, TruckType type)
            :base(model,brand,year,price, me, e)
        {
            this._type = type;
        }

        public void setType(TruckType t) { this._type = t;}
        public new string getType()
        {
            switch(this._type)
            {
                case TruckType.Ambulance:
                    return "Ambulance";
                case TruckType.FireTruck:
                    return "fire truck";
                case TruckType.CarTransporter:
                    return "car transporter";
                case TruckType.Pickup:
                    return "pickup";
                default:
                    return "truck";
            }
        }

        public override string ToString()
        {
            return base.ToString() + String.Format("Truck type:{0}", this.getType());
        }
    }
}
