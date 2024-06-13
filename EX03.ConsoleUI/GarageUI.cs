using EX03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class GarageUI
    {
        private GarageManagement garageManagement;

        public GarageUI()
        {
            this.garageManagement = new GarageManagement();
        }

        public void Run()
        {
            bool continueRunning = true;
            while (continueRunning)
            {
                Console.Clear();
                ShowMainMenu();
                try
                {
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            InsertNewVehicle();
                            break;
                        case 2:
                            DisplayVehicles();
                            break;
                        case 3:
                            ChangeVehicleStatus();
                            break;
                        case 4:
                            InflateTires();
                            break;
                        case 5:
                            RefuelVehicle();
                            break;
                        case 6:
                            RechargeVehicle();
                            break;
                        case 7:
                            DisplayVehicleDetails();
                            break;
                        case 0:
                            continueRunning = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input, please enter a number.");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private void ShowMainMenu()
        {
            Console.WriteLine("Garage Management System:");
            Console.WriteLine("1. Insert a new vehicle");
            Console.WriteLine("2. Display all vehicles' license numbers");
            Console.WriteLine("3. Change a vehicle's status");
            Console.WriteLine("4. Inflate tires to maximum");
            Console.WriteLine("5. Refuel a vehicle");
            Console.WriteLine("6. Recharge a vehicle");
            Console.WriteLine("7. Display vehicle details");
            Console.WriteLine("0. Exit");
            Console.WriteLine("Enter your choice:");
        }

        private void InsertNewVehicle()
        {
            Console.WriteLine("Enter vehicle type (ElectricMotorcycle, FuelMotorcycle, ElectricCar, FuelCar, FuelTruck):");
            string vehicleTypeStr = Console.ReadLine();
            if (!Enum.TryParse(vehicleTypeStr, out eVehicleType vehicleType))
            {
                Console.WriteLine("Invalid vehicle type.");
                return;
            }

            Console.WriteLine("Enter license plate:");
            string licensePlate = Console.ReadLine();

            if (garageManagement.CheckIfCarExistsInGarage(licensePlate))
            {
                garageManagement.ChangeVehicleCondition(licensePlate, eVehicleCondition.InRepair);
                Console.WriteLine("Vehicle found in garage. Status set to 'In Repair'.");
            }
            else
            {
                Console.WriteLine("Enter owner name:");
                string ownerName = Console.ReadLine();
                Console.WriteLine("Enter owner phone number:");
                string ownerPhone = Console.ReadLine();
                Owner owner = new Owner { Name = ownerName, PhoneNumber = ownerPhone };

                Console.WriteLine("Enter model name:");
                string modelName = Console.ReadLine();

                Vehicle vehicle = Factory.CreateVehicle(vehicleType, owner, modelName, licensePlate);
                garageManagement.AddCarToGarage(vehicle);
                garageManagement.ChangeVehicleCondition(licensePlate, eVehicleCondition.InRepair);

                Console.WriteLine("Enter the manufacturer for all wheels:");
                string manufacturer = Console.ReadLine();
                Console.WriteLine(string.Format("Enter the air pressure for all wheels (Max {0} psi):", vehicle.TierSet[0].MaxAirPressure));
                float airPressure;
                bool airPressureValid = float.TryParse(Console.ReadLine(), out airPressure) && airPressure <= vehicle.TierSet[0].MaxAirPressure && airPressure >= 0;

                List<string> userDetails = new List<string>();
                try
                {
                    foreach (string question in vehicle.QuestionForUserToUpdatingParams)
                    {
                        Console.WriteLine(question);
                        string answer = Console.ReadLine();
                        userDetails.Add(answer); 
                    }

         
                    if (!airPressureValid)
                    {
                        throw new ArgumentException("Invalid air pressure. Must be a numeric value within the allowed range.");
                    }
                    foreach (Tire wheel in vehicle.TierSet)
                    {
                        wheel.ManufactureName= manufacturer;
                        wheel.CurrentAirPressure = airPressure;
                    }
                    vehicle.UpdateDetails(userDetails);
                    Console.WriteLine("Vehicle and wheel details updated successfully and set to 'In Repair'.");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Error processing input: " + ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Validation error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An unexpected error occurred: " + ex.Message);
                }
            }
        }

        private void DisplayVehicles()
        {
            Console.WriteLine("Do you want to filter by vehicle status? (yes/no)");
            string filterResponse = Console.ReadLine().ToLower();
            bool filterByCondition = filterResponse.StartsWith("y");
            if (filterByCondition)
            {
                Console.WriteLine("Enter vehicle condition (InRepair, Repaired, Payed):");
                if (!Enum.TryParse(Console.ReadLine(), out eVehicleCondition condition))
                {
                    Console.WriteLine("Invalid condition.");
                    return;
                }
                List<string> licenses = garageManagement.ShowLicensePlates(true, condition);
                foreach (var license in licenses)
                {
                    Console.WriteLine(license);
                }
            }
            else
            {
                List<string> licenses = garageManagement.ShowLicensePlates(false);
                foreach (var license in licenses)
                {
                    Console.WriteLine(license);
                }
            }
        }

        private void ChangeVehicleStatus()
        {
            Console.WriteLine("Enter the license plate of the vehicle:");
            string licensePlate = Console.ReadLine();
            if (!garageManagement.CheckIfCarExistsInGarage(licensePlate))
            {
                Console.WriteLine("No vehicle with this license plate found in the garage.");
                return;
            }

            Console.WriteLine("Enter new status (InRepair, Repaired, Payed):");
            if (!Enum.TryParse(Console.ReadLine(), out eVehicleCondition newCondition))
            {
                Console.WriteLine("Invalid status.");
                return;
            }

            try
            {
                garageManagement.ChangeVehicleCondition(licensePlate, newCondition);
                Console.WriteLine("Vehicle status updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Error: {0}", ex.Message));
            }
        }

        private void InflateTires()
        {
            Console.WriteLine("Enter the license plate of the vehicle:");
            string licensePlate = Console.ReadLine();
            if (!garageManagement.CheckIfCarExistsInGarage(licensePlate))
            {
                Console.WriteLine("No vehicle with this license plate found in the garage.");
                return;
            }

            try
            {
                garageManagement.PumpAir(licensePlate);
                Console.WriteLine("Tires inflated to maximum.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Error: {0}", ex.Message));
            }
        }

        private void RefuelVehicle()
        {
            Console.WriteLine("Enter the license plate of the vehicle:");
            string licensePlate = Console.ReadLine();
            if (!garageManagement.CheckIfCarExistsInGarage(licensePlate))
            {
                Console.WriteLine("No vehicle with this license plate found in the garage.");
                return;
            }

            Console.WriteLine("Enter fuel type (Octan98, Octan96, Octan95, Soler):");
            if (!Enum.TryParse(Console.ReadLine(), out eFuelType fuelType))
            {
                Console.WriteLine("Invalid fuel type.");
                return;
            }
            Console.WriteLine("Enter the amount of fuel to add:");
            float fuelAmount = float.Parse(Console.ReadLine());

            try
            {
                garageManagement.Refuel(licensePlate, fuelType, fuelAmount);
                Console.WriteLine("Vehicle refueled successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Error: {0}", ex.Message));
            }
        }

        private void RechargeVehicle()
        {
            Console.WriteLine("Enter the license plate of the vehicle:");
            string licensePlate = Console.ReadLine();
            if (!garageManagement.CheckIfCarExistsInGarage(licensePlate))
            {
                Console.WriteLine("No vehicle with this license plate found in the garage.");
                return;
            }

            Console.WriteLine("Enter the number of minutes to charge:");
            float minutesToCharge = float.Parse(Console.ReadLine());

            try
            {
                garageManagement.ReCharge(licensePlate, minutesToCharge);
                Console.WriteLine("Vehicle charged successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Error: {0}", ex.Message));
            }
        }

        private void DisplayVehicleDetails()
        {
            Console.WriteLine("Enter the license plate of the vehicle:");
            string licensePlate = Console.ReadLine();
            if (!garageManagement.CheckIfCarExistsInGarage(licensePlate))
            {
                Console.WriteLine("No vehicle with this license plate found in the garage.");
                return;
            }

            try
            {
                string details = garageManagement.GetVehicleDetails(licensePlate);
                Console.WriteLine(details);
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Error: {0}", ex.Message));
            }
        }
    }
}
