using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace EX03.GarageLogic
{
    public abstract class Engine
    {
        private bool m_IsElectric {  get; set; }
        private float m_EnergyCapacity { get; set; }
        private float m_EnergyLeft {  get; set; }

        public float EnergyCapacity
        {
            get { return m_EnergyCapacity; }
            set { m_EnergyCapacity = value; } 
        }

        public float EnergyLeft
        {
            get { return m_EnergyLeft; }
            set { m_EnergyLeft = value; }
        }

        public bool IsEngineElectric
        {
            get { return m_IsElectric; }
            set { m_IsElectric = value; }
        }
        public virtual string ToString()
        {
            string engineType = m_IsElectric ? "Electric" : "Fuel";
            return String.Format("Engine type: {0}", engineType);
        }
    }
}
