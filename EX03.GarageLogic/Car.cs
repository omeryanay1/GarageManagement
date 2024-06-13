using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        private const int k_NumberOfWheels = 4;
        private const int k_MaximumWheelPresure = 32;
        private readonly List<string> r_QuestionsToAsk = new List<string>() { "what is the color of the car? (Yellow/White/Red/Black)?", "How many doors there is in the car?" };
        private eNumberOfDoorsInCAR m_NumberOfDoors;
        private eColorOfCar m_CarColor;

        public eNumberOfDoorsInCAR NumberOfDoors
        {
            get { return m_NumberOfDoors; }
            set { m_NumberOfDoors = value; }
        }

        public eColorOfCar ColorOfCar
        {
            get { return m_CarColor; }
            set { m_CarColor = value; }
        }

        public Car(Owner i_Owner, string i_ModelName, string i_LicensePlate) : base(i_Owner, i_ModelName, i_LicensePlate)
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
            eColorOfCar carColor;
            eNumberOfDoorsInCAR numberOfDoors;
            bool isValidEnum = Enum.TryParse(i_UserInput[0], out carColor);
            if (isValidEnum)
            {
                m_CarColor = carColor;
            }
            else
            {
                throw new FormatException("Color must be (Yellow/Black/Red/White)");
            }
            isValidEnum = Enum.TryParse(i_UserInput[1], out numberOfDoors);
            if (isValidEnum)
            {
                m_NumberOfDoors = numberOfDoors;
            }
            else
            {
                throw new FormatException("Number of doors in car must be (2/3/4/5");
            }
            
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(@"Number of doors: {0},
Color: {1}", m_NumberOfDoors, m_CarColor);
        }
    }
}
