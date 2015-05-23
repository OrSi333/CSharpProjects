using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class ValueOutOfRangeException : Exception
    {
        private float m_CurrentQuantity;
        private float m_MaxCapacity;
        private float m_Quantity;
        private Exception innerException;

         protected float CurrentQuantity
        {
             get { return m_CurrentQuantity; }
        }

        protected float MaxCapacity
        {
            get { return m_MaxCapacity; }
        } 

        protected float Quantity
        {
            get { return m_Quantity; }
        }

        public ValueOutOfRangeException (float i_CurrentQuantity, float i_MaxCapacity, float i_Quantity)
            // sending two params to the base CTOR:
            : base(string.Format("Error, you are trying to fill the engine with {0} fuel when the current capacity of the engine is {1}, but the max capacity is {2}", i_Quantity, i_CurrentQuantity, i_MaxCapacity))
        {
            m_CurrentQuantity = i_CurrentQuantity;
            m_MaxCapacity = i_MaxCapacity;
            m_Quantity = i_Quantity;
        }
        
    }
}
