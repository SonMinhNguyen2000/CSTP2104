using System.Net.Http.Headers;
using System.Security.Cryptography;
using Assignment1.Enum;
using Assignment1.Interface;
namespace Assignment1.Entity
{
    public class Vehicle:IPrint
    {
        VehicleType _vehicleType;
        string _brand;
        string _model;
        int _year;
        int _price;
        Engines _engine;
        int _mileage;
        public Vehicle(string b, string m, int y, int p, int me, Engines e)
        {
            this._brand = b;
            this._year = y;
            this._model = m;
            this._price = p;
            this._mileage = me;
            this._engine = e;
        }
        public string getType()
        {
            switch (this._vehicleType)
            {
                case VehicleType.FourWheel:
                    return "four wheel";
                case VehicleType.TwoWheel:
                    return "two wheel";
                default:
                    return "empty";
           }
        }

        public void setVehicleType(VehicleType v)
        {
            this._vehicleType = v;
        }

        public void setModel(string m) { this._model = m; }

        public string getModel() { return this._model; }

        public void setBrand(string b) { this._brand = b; }

        public string getBrand() { return this._brand; }

        public void setYear(int y) { this._year = y; }

        public int getYear() { return this._year; }

        public void setPrice(int p) { this._price = p; }

        public int getPrice() { return this._price; }

        public string getEngine()
        {
            switch (_engine)
            {
                case Engines.OneCylinder:
                    return "one cylinder";
                case Engines.TwoCylinder:
                    return "two cylinder";
                case Engines.ThreeCylinder:
                    return "three cylinder";
                case Engines.FourCylinder:
                    return "four cylinder";
            }
            return "";
        }
        
        public int getMileage()
        {
            return _mileage;
        }

        public void setMileage(int me)
        {
            _mileage = me;
        }
        
        //return vehicle info as a string
        public override string ToString()
        {
            return String.Format("Model:{0}\n" +
                "Brand:{1}\n" +
                "Engine:{5}\n" +
                "Mileage: {6} km\n" +
                "Year:{2}\n" +
                "Price:{3} $\n" +
                "Vehicle type:{4}\n", 
                this.getModel(), this.getBrand(), this.getYear().ToString(), 
                this.getPrice().ToString(), this.getType(), this.getEngine(), this.getMileage());
        }

        //convert mileage from km to mile
        //mileage is km by default
        public int mileageConverter()
        {
            int mile = (int) (_mileage * 0.621371);
            return mile;
        }
    }
}
