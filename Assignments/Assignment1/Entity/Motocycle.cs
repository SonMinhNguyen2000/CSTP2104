using Assignment1.Enum;
using Assignment1.Interface;
namespace Assignment1.Entity
{
    public class Motocycle:Vehicle, IPrint
    {
        MotocycleType type;

        public Motocycle(string model, string brand, int year, int price, MotocycleType type):base(model, brand, year, price)
        {
            this.type = type;
            this.vehicleType = VehicleType.two_wheel;
        }

        public string getType()
        {
            switch (this.type) 
            {
                case MotocycleType.touring:
                    return "touring";
                case MotocycleType.sport:
                    return "sport";
                case MotocycleType.cruiser:
                    return "cruiser";
                default:
                    return "motobike";
            }

        }

        override public string ToString()
        {
            return base.ToString() + "Type:"+this.getType();
        }
    }
}
