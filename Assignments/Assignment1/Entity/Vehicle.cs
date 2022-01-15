using System.Net.Http.Headers;
using System.Security.Cryptography;
using Assignment1.Enum;
using Assignment1.Interface;
namespace Assignment1.Entity
{
    public class Vehicle:IPrint
    {
        VehicleTypes _vehicleType;
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
        
        public string getVehicleType()
        {
            switch (this._vehicleType)
            {
                case VehicleTypes.FourWheel:
                    return "four wheel";
                case VehicleTypes.TwoWheel:
                    return "two wheel";
                default:
                    return "empty";
           }
        }

        public VehicleTypes VehicleType
        {
            set => _vehicleType = value;
        }

        public string Model
        {
            get => _model;
            set => _model = value;
        }

        public string Brand
        {
            get => _brand;
            set => _brand = value;
        }

        public int Year
        {
            get => _year;
            set
            {
                if (value < 2007) throw new Exception("Please Enter valid Year");
                _year = value;
            }
        }

        public int Price
        {
            get => _price;
            set
            {
                if (value < 0) throw new Exception("Please Enter valid Year");
                _price = value;
            }
        }

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

        public Engines Engine
        {
            set => _engine = value;
        }
        public int Mileage
        {
            get => _mileage;
            set
            {
                if (Mileage < 0) throw new Exception("Please enter valid Mileage");
                _mileage = value;
            }
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
                _model, _brand, _year.ToString(), 
                _price.ToString(), getVehicleType(), getEngine(), _mileage);
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
