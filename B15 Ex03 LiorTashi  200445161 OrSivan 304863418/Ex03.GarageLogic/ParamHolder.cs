using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ParamHolder
    {
        private object m_Value;
        private String m_Description;
        private Type m_expectedType;

        public ParamHolder(String i_Description, Type i_ExpectedType)
        {
            m_Description = i_Description;
            m_expectedType = i_ExpectedType;
            m_Value = null;
        }

        public object Value
        {
            get
            {
                return m_Value;
            }
            set
            {
                if (value.GetType().Equals(m_expectedType))
                {
                    m_Value = value;
                }
                else
                {
                    throw new ArgumentException(string.Format("Expected to get {0}", m_expectedType), value.GetType().ToString());
                }
            }
        }

        public Type ExpectedType
        {
            get
            {
                return m_expectedType;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is string)
            {
                return ((string)obj).Equals(m_Description);
            }
            else if (obj is ParamHolder)
            {
                return ((ParamHolder)obj).m_Description.Equals(this.m_Description); 
            }
            else
            {
                throw new ArgumentException("Tries to compare ParamHolder with the wrong type", obj.GetType().ToString());
            }
        }

        public override string ToString()
        {
            return m_Description;
        }
    }
}
