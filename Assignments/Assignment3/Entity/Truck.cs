namespace Assignment3.Entity;

public class Truck:Vehicle
{
    public Truck(string m,string b, int y, double fcy, double fc)
    {
        Model = m;
        Brand = b;
        Year = y;
        FuelCapacity = fcy;
        FuelConsumption = fc;
    }

    //calculate possible distance with the amount of fuel left
    public override double DistanceCalculate(double milesDriven)
    {
        //Fuel left * Fuel Consumption
        return (FuelCapacity - (milesDriven / FuelConsumption))*FuelConsumption;
    }

    //calculate fuel needed for specific distance
    public override double FuelCalculate(double distance)
    {
        return distance / FuelConsumption;
    }

    //calculate fuel level
    public override string FuelLevel(double milesDriven)
    {
        switch ((milesDriven / FuelConsumption) / FuelCapacity)
        {
            case <= 0.25:
                return "Green";
            case >= 0.75:
                return "Red";
            default:
                return "Yellow";
        }
        
    }

    public override string ToString()
    {
        return "Truck info:\n" + base.ToString();
    }
}