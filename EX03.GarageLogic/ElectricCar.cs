using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX03.GarageLogic
{
    public class ElectricCar : Car
    {
        private const float k_MaximumElectricCapacity = 12.3f;
        public ElectricCar(Owner i_Owner, string i_ModelName, string i_LicensePlate)
: base(i_Owner, i_ModelName, i_LicensePlate)
        {
            Engine = new ElectricEngine(k_MaximumElectricCapacity);
        }
    }
}
