using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX03.GarageLogic
{
    public class FuelEngine : Engine
    {
        private eFuelType m_FuelType;
        public eFuelType FuelType
        {
            get { return m_FuelType; }
        }
        public FuelEngine(eFuelType i_FuelType, float i_FuelCapacity)
        {
            IsEngineElectric = false;
            EnergyCapacity = i_FuelCapacity;
            EnergyLeft = 0;
            m_FuelType = i_FuelType;
        }

        public void ReFuel(float i_FuelAmount, eFuelType i_FuelType)
        {
            if (EnergyLeft + i_FuelAmount > EnergyCapacity)
            {
                throw new ValueOutOfRangeException(0, EnergyCapacity - EnergyLeft);
            }
            else if(m_FuelType != i_FuelType) 
            {
                throw new ArgumentException(string.Format("The vehicle you are trying to refuel is not supporting {0} fuel.", i_FuelType));
            }
            else
            {
                EnergyLeft += i_FuelAmount;
            }
        }
        public override string ToString()
        {
            return String.Format(@"{0}, 
Fuel type: {1}", base.ToString(), FuelType);
        }
    }
}
