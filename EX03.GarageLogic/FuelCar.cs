using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX03.GarageLogic
{
    public class FuelCar : Car
    {
        private const float k_MaxFuelCapacity = 28.4f;
        private const eFuelType k_FuelType = eFuelType.Octan95;
        public eFuelType FuelType
        {
            get { return k_FuelType; }
        }

        public FuelCar(Owner i_Owner, string i_ModelName, string i_LicensePlate)
: base(i_Owner, i_ModelName, i_LicensePlate)
        {
            Engine = new FuelEngine(k_FuelType, k_MaxFuelCapacity);
        }
    }
}
