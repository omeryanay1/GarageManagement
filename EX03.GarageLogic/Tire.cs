using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX03.GarageLogic
{
    public class Tire
    {
        private string m_ManufactureName;
        public string ManufactureName
        {
            get { return m_ManufactureName; }
            set { m_ManufactureName = value;}
        }
        private float m_CurrentAirPressure;
        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }
        }
        private float m_MaxAirPressure;

        public float MaxAirPressure
        {
            get { return m_MaxAirPressure; }
            set { m_MaxAirPressure = value; }
        }

        public Tire(float i_MaxAirPressure)
        {
            m_MaxAirPressure = i_MaxAirPressure;
            m_CurrentAirPressure = 0;
        }

        public void AirFilling(float i_AirToAdd)
        {
            if(m_CurrentAirPressure + i_AirToAdd > m_MaxAirPressure)
            {
                throw new ValueOutOfRangeException(0, m_MaxAirPressure - m_CurrentAirPressure);
            }
            else
            {
                m_CurrentAirPressure += i_AirToAdd;
            }
        }

        public override string ToString()
        {
            return String.Format("Air pressure: {0}, Manufacturer: {1}", m_CurrentAirPressure, m_ManufactureName);
        }

    }
}
