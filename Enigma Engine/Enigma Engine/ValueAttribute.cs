using System;
using System.Collections.Generic;

namespace Enigma
{
    public enum ValueType
    {
        String,
        Int,
        Float,
        Boolean,
        Angle,
        Position,
        List,
        Entity,
        Model,
        Sound,
        Particle,
        Material,
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
