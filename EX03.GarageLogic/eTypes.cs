using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX03.GarageLogic
{
    public enum eVehicleCondition
    {
        InRepair,
        Repaired,
        Payed,
        none
    }
    public enum eFuelType
    {
        Octan98,
        Octan96,
        Octan95,
        Soler
    }

    public enum eMotorcycleLicenseType
    {
        A,
        A1,
        AA,
        B1
    }

    public enum eNumberOfDoorsInCAR
    {
        Tow = 2,
        Three = 3,
        Four = 4,
        Five = 5
    }

    public enum eColorOfCar
    {
        Yellow,
        White,
        Red,
        Black
    }

    public enum eVehicleType
    {
        ElectricMotorcycle,
        FuelMotorcycle,
        ElectricCar,
        FuelCar,
        FuelTrunk
    }
}
