using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_EnergyCapacity)
        {
           IsEngineElectric = true;
           EnergyCapacity = i_EnergyCapacity;
            EnergyLeft = 0;
        }

        public void ReCharge(float i_CharchingTime)
        {
            if(EnergyLeft + i_CharchingTime > EnergyCapacity)
            {
                throw new ValueOutOfRangeException(0, EnergyCapacity - EnergyLeft);
            }
            else
            {
                EnergyLeft += i_CharchingTime;
            }
        }
    }
}
