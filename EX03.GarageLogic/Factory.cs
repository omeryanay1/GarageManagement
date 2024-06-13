using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX03.GarageLogic
{
    public class Factory
    {
        public static Vehicle CreateVehicle(eVehicleType i_VehicleType ,Owner i_Owner, string i_ModelName, string i_LicensePlate)
        {
            Vehicle vehicle = null;
            switch (i_VehicleType)
            {
                case eVehicleType.ElectricMotorcycle:
                    vehicle = new ElectricMotorcycle(i_Owner, i_ModelName, i_LicensePlate);
                    break;
                case eVehicleType.FuelMotorcycle:
                    vehicle = new FuelMotorcycle(i_Owner,i_ModelName, i_LicensePlate);
                    break;
                case eVehicleType.ElectricCar:
                    vehicle = new ElectricCar(i_Owner, i_ModelName, i_LicensePlate);
                    break;
                case eVehicleType.FuelCar:
                    vehicle = new FuelCar(i_Owner, i_ModelName, i_LicensePlate);
                    break;
                case eVehicleType.FuelTrunk:
                    vehicle = new FuelTruck(i_Owner, i_Owner.Name, i_LicensePlate); 
                    break;
            }
            return vehicle;
        }
    }
}
