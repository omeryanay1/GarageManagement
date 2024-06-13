using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX03.GarageLogic
{
    public class GarageManagement
    {
        private Dictionary<string, Vehicle> m_CarsInGarage = new Dictionary<string, Vehicle>();

        public bool CheckIfCarExistsInGarage(string i_LicensePlate)
        {
            bool carExist;
            foreach(string licenseplate in m_CarsInGarage.Keys)
            {
                if(i_LicensePlate == licenseplate)
                {
                    return carExist = true; ;
                }
            }
            carExist = false;
            return carExist;
        }

        public void AddCarToGarage(Vehicle i_vehicle)
        {
            m_CarsInGarage[i_vehicle.licensePlate] = i_vehicle; 
        }

        public List<string> ShowLicensePlates(bool i_FilterByCondition, eVehicleCondition i_VehicleCondition = eVehicleCondition.none)
        {
            List<string> allLicensePlates = new List<string>(m_CarsInGarage.Keys);
            List<string> finalResult = new List<string>();

            if(!i_FilterByCondition)
            {
                finalResult = allLicensePlates;
            }
            else
            {
                foreach(string licensePlate in allLicensePlates)
                {
                    if (m_CarsInGarage[licensePlate].VehicleCondition == i_VehicleCondition)
                    {
                        finalResult.Add(licensePlate);
                    }
                }
            }
            return finalResult;
        }

        public void ChangeVehicleCondition(string i_LicensePlate, eVehicleCondition i_NewCondition)
        {
            m_CarsInGarage[i_LicensePlate].VehicleCondition = i_NewCondition;
        }

        public void PumpAir(string i_LicensePlate)
        {
            foreach(Tire tire in m_CarsInGarage[i_LicensePlate].TierSet)
            {
                tire.AirFilling(tire.MaxAirPressure - tire.CurrentAirPressure);
            }
        }

        public void Refuel(string i_LicensePlate, eFuelType i_FuelType, float i_FuelAmount)
        {
            Engine currentEngine = m_CarsInGarage[i_LicensePlate].getEngine;
            if (!(currentEngine is FuelEngine))
            {
                throw new ArgumentException("You are trying to refuel electric car");
            }
            try
            {
                (currentEngine as FuelEngine).ReFuel(i_FuelAmount, i_FuelType);
            }
            catch(ValueOutOfRangeException error)
            {
                throw error;
            }
            catch(ArgumentException error)
            {
                throw error;
            }

        }

        public void ReCharge(string i_LicensePlate, float i_MintuesToCharge)
        {
            float hoursToCharge = i_MintuesToCharge / 60;
            Engine currentEngine = m_CarsInGarage[i_LicensePlate].getEngine;
            if (!(currentEngine is ElectricEngine))
            {
                throw new ArgumentException("You are trying to recharge fuel car");
            }
            try
            {
                (currentEngine as ElectricEngine).ReCharge(hoursToCharge);
            }
            catch (ValueOutOfRangeException error)
            {
                throw error;
            }
        }
        public string GetVehicleDetails(string i_LicensePlate)
        {
            return m_CarsInGarage[i_LicensePlate].ToString();
        }
    }
}
