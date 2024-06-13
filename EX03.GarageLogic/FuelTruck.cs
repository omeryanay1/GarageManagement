using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX03.GarageLogic
{
    public class FuelTruck : Truck
    {
        private const float k_MaxFuelCapacity = 120f;
        private const eFuelType k_FuelType = eFuelType.Soler;
        public eFuelType FuelType
        {
            get { return k_FuelType; }
        }

        public FuelTruck(Owner i_Owner, string i_ModelName, string i_LicensePlate)
: base(i_Owner, i_ModelName, i_LicensePlate)
        {
            Engine = new FuelEngine(k_FuelType, k_MaxFuelCapacity);
        }
    }
}
