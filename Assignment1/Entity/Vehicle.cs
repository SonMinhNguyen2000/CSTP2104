using Assignment1.Enum;
using Assignment1.Interface;
namespace Assignment1.Entity
{
    public class Vehicle:IPrint
    {
        public VehicleType vehicleType;
        string brand;
        string model;
        int year;
        int price;
        public Vehicle(string b, string m, int y, int p)
        {
            this.brand = b;
            this.year = y;
            this.model = m;
            this.price = p;
        }
        public string getType()
        {
            switch (this.vehicleType)
            {
                case VehicleType.four_wheel:
                    return "four wheel";
                case VehicleType.two_wheel:
                    return "two wheel";
                default:
                    return "empty";
           }
        }

        public void setModel(string m) { this.model = m; }

        public string getModel() { return this.model; }

        public void setBrand(string b) { this.brand = b; }

        public string getBrand() { return this.brand; }

        public void setYear(int y) { this.year = y; }

        public int getYear() { return this.year; }

        public void setPrice(int p) { this.price = p; }

        public int getPrice() { return this.price; }

        override public string ToString()
        {
            return String.Format("Model:{0}\n" +
                "Brand:{1}\n" +
                "Year:{2}\n" +
                "Price:{3}\n" +
                "Vehical type:{4}\n", 
                this.getModel(), this.getBrand(), this.getYear().ToString(), this.getPrice().ToString(), this.getType());
        }
    }
}
