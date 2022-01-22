using Assignment1.Enum;

namespace Assignment1.Entity
{
    public class Car : Vehicle
    {
        public Car(string m, string b, int y, int p, int me ,Engines e):base(m, b, y, p, me,e)
        {
            this.VehicleType = VehicleTypes.FourWheel;
        }
    }
}
