using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        protected string m_LicensePlate;
        private Engine m_Engine;
        private List<Tire> m_TireSet;
        private Owner m_Owner;
        private eVehicleCondition m_VehicleCondition;
        protected List<string> m_QuestionForUserToUpdatingParams;

        public List<string> QuestionForUserToUpdatingParams
        {
            get { return m_QuestionForUserToUpdatingParams; }
        }

        public Engine getEngine
        {
            get { return m_Engine; }
        }
        public string licensePlate
        {
            get { return m_LicensePlate; }
        }
        public eVehicleCondition VehicleCondition
        {
            get { return m_VehicleCondition; }
            set { m_VehicleCondition = value; }
        }
        public Vehicle(Owner i_Owner, string i_ModelName, string i_LicensePlate)
        {
            m_Owner = i_Owner;
            m_ModelName = i_ModelName;
            m_LicensePlate = i_LicensePlate;
        }
        public List<Tire> TierSet
        {
            get { return m_TireSet; }
            set { m_TireSet = value; }
        }
        public Owner Owner
        {
            get {  return m_Owner; }
        }

        public string ModelName
        {
            get { return m_ModelName; }
            set { m_ModelName = value; }
        }
        public Engine Engine
        {
            get { return m_Engine; }
            set { m_Engine = value; }
        }
        public float EnergyLeft
        {
            get { return ((m_Engine.EnergyLeft / m_Engine.EnergyCapacity) * 100); }
        }
        public abstract void UpdateDetails(List<String> i_UserInput);

        public override int GetHashCode()
        {
            return m_LicensePlate.GetHashCode();
        }
        public override string ToString()
        {
            StringBuilder details = new StringBuilder();
            details.AppendLine(String.Format("Model type: {0}", m_ModelName));
            details.AppendLine(String.Format("License plate: {0}", m_LicensePlate));
            details.AppendLine(String.Format("Owner name: {0}", m_Owner.Name));
            details.AppendLine(String.Format("Owner phone number: {0}", m_Owner.PhoneNumber));
            details.AppendLine(String.Format("Vehicle condition: {0}", m_VehicleCondition));
            details.AppendLine(Engine.ToString());
            details.AppendLine(String.Format("Energy left: {0:0.00}%", EnergyLeft));

            details.AppendLine("\nTire Details:");
            int tireNumber = 1;
            foreach (Tire tire in m_TireSet)
            {
                details.AppendLine(String.Format("Tire {0}: {1}", tireNumber, tire.ToString()));
                tireNumber++;
            }

            return details.ToString();
        }
    }
}
    


