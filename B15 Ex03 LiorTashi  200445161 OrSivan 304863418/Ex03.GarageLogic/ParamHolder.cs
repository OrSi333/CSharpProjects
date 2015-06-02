using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ParamHolder
    {
        object m_Value;
        String m_Description;
        Type m_expectedType;

        public ParamHolder(String i_Description, Type i_ExpectedType)
        {
            m_Description = i_Description;
            m_expectedType = i_ExpectedType;
        }

        public object Value
        {
            get
            {
                return m_Value;
            }
            set
            {
                if (value is m_expectedType)
                {
                    m_Value = value;
                }
                else
                {
                    throw new ArgumentException(string.Format("Expected to get {0}", m_expectedType), value.GetType());
                }
            }
        }

        public Type ExpectedType
        {
            get
            {
                return m_Value.GetType();
            }
        }

        public override string ToString()
        {
            return m_Description;
        }
    }
}
