using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsAppLib.OOD
{
    public class Car
    {
        public string Model;
        public string Brand;
        public int Year;
        public string Trim;
        public string Bodytype;
        public engines Engine;

        public string getEngine()
        {
            switch(this.Engine){
                case engines.one_cylinders:
                    return "one cylinder";
                case engines.two_cylinders:
                    return "two cylinders";
                case engines.three_cylinders:
                    return "three cylinders";
                case engines.four_cylinders:
                    return "four cylinders";
                default:
                    return "1 cylinder";
            }
        }
    }
}
