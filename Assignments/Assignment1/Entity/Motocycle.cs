using Assignment1.Enum;
using Assignment1.Interface;
namespace Assignment1.Entity
{
    public class Motorcycle:Vehicle, IPrint
    {
        MotorcycleType _type;

        public Motorcycle(string model, string brand, int year, int price, int mileage, Engines e,
            MotorcycleType type) :
            base(model, brand, year, price, mileage, e)
        {
            this._type = type;
            this.setVehicleType(VehicleType.TwoWheel);
        }

        public new string getType()
        {
            switch (this._type) 
            {
                case MotorcycleType.Touring:
                    return "touring";
                case MotorcycleType.Sport:
                    return "sport";
                case MotorcycleType.Cruiser:
                    return "cruiser";
                default:
                    return "motorbike";
            }

        }

        public override string ToString()
        {
            return base.ToString() + "Type:"+this.getType();
        }
    }
}
