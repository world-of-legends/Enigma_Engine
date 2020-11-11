using System;
using System.Collections.Generic;
using System.Text;

namespace Enigma
{
    public enum ValueType
    {
        String,
        Int,
        Float,
        Angle,
        Position,
        List,
        Entity,
        Model,
        Sound,
        Color,
        Script
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ValueAttribute : Attribute
    {
        public string ValueName { set; get; }
        public string Comment { set; get; }
        public ValueType Type { set; get; }
    }
}
