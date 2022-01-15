using Assignment1.Enum;
using Assignment1.Interface;
namespace Assignment1.Entity
{
    public class Motorcycle:Vehicle, IPrint
    {
        MotorcycleTypes _type;

        public Motorcycle(string model, string brand, int year, int price, int mileage, Engines e,
            MotorcycleTypes type) :
            base(model, brand, year, price, mileage, e)
        {
            _type = type;
            VehicleType = VehicleTypes.TwoWheel;
        }

        public string getType()
        {
            switch (this._type) 
            {
                case MotorcycleTypes.Touring:
                    return "touring";
                case MotorcycleTypes.Sport:
                    return "sport";
                case MotorcycleTypes.Cruiser:
                    return "cruiser";
                default:
                    return "motorbike";
            }
        }

        public MotorcycleTypes MotorcycleType
        {
            set => _type = value;
        }

        public override string ToString()
        {
            return base.ToString() + "Type:"+getType();
        }
    }
}
