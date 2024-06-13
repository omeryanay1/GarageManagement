using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        private const int k_NumberOfWheels = 2;
        private const int k_MaximumWheelPresure = 14;
        private readonly List<string> r_QuestionsToAsk = new List<string>() { "what type of license do you have? (A/A1/B1/BB)?", "What is your engine volume?" };
        private eMotorcycleLicenseType m_LicenceType;
        public eMotorcycleLicenseType licenseType
        {
            get { return m_LicenceType; }
            set { m_LicenceType = value; }
        }

        private int m_EngineVolume;
        public int EngineVolume
        {
            get { return m_EngineVolume; }
            set { m_EngineVolume = value; }
        }

        public Motorcycle(Owner i_Owner, string i_ModelName, string i_LicensePlate) : base(i_Owner, i_ModelName, i_LicensePlate)
        {
            TierSet = new List<Tire>(k_NumberOfWheels);
            for(int i=0; i<k_NumberOfWheels; i++)
            {
                TierSet.Add(new Tire(k_MaximumWheelPresure));
            }
            m_QuestionForUserToUpdatingParams = r_QuestionsToAsk;
            
        }

        public override void UpdateDetails(List<string> i_UserInput)
        {
            eMotorcycleLicenseType licenceType;
            bool isValidEnum = Enum.TryParse(i_UserInput[0], out licenceType);
            if (isValidEnum)
            {
                m_LicenceType = licenceType;
            }
            else
            {
                throw new FormatException("License need to be in the right form");
            }
            if (!int.TryParse(i_UserInput[1], out int EngaineVolume))
            {
                throw new FormatException("Engine volume must be a valid integer.");
            }
            m_EngineVolume = EngaineVolume;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(@"License type: {0},
Engine volume: {1}", m_LicenceType, m_EngineVolume);
        }
    }
}
