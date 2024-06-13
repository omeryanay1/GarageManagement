using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX03.GarageLogic
{
    public abstract class Truck : Vehicle
    {
        private const int k_NumberOfWheels = 16;
        private const int k_MaximumWheelPresure = 47;  
        private readonly List<string> r_QuestionsToAsk = new List<string>()
        {
            "What is the truck volume?",
            "Is the truck refrigerated? (Y/N)"
        };
        private bool m_IsRefrigerated;
        private float m_TruckVolume;

        public bool IsRefrigerated
        {
            get { return m_IsRefrigerated; }
            set { m_IsRefrigerated = value; }
        }

        public float TruckVolume
        {
            get { return m_TruckVolume; }
            set { m_TruckVolume = value; }
        }

        public Truck(Owner i_Owner, string i_ModelName, string i_LicensePlate) : base(i_Owner, i_ModelName, i_LicensePlate)
        {
            TierSet = new List<Tire>(k_NumberOfWheels);
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                TierSet.Add(new Tire(k_MaximumWheelPresure));
            }
            m_QuestionForUserToUpdatingParams = r_QuestionsToAsk;
        }

        public override void UpdateDetails(List<string> i_UserInput)
        {
            bool isValid;
            isValid = float.TryParse(i_UserInput[0], out float truckVolume);
            if (isValid)
            {
                m_TruckVolume = truckVolume;
            }
            else
            {
                throw new FormatException("Truck volume must be valid float.");
            }
            if (i_UserInput[1] == "Y")
            {
                m_IsRefrigerated = true;
            }
            else if (i_UserInput[1] == "N")
            {
                m_IsRefrigerated = false;
            }
            else
            {
                throw new FormatException("Refrigerated status must be either 'Y' or 'N'.");
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(@"Volume: {0},
Is Refrigrerated: {1} "
, m_TruckVolume, m_IsRefrigerated);
        }
    }
}