namespace WindowsAppLib.OOD
{
    public class Vehicle
    {
        public string Model;
        public Makes Make;
        public int Year;
        public Engines Engine;

        public virtual int GetMaxSpeed()
        {
            return 0;
        }
    }
}