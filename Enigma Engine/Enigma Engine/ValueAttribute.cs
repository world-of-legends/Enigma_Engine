using System;
using System.Collections.Generic;
using System.Text;

namespace Enigma
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ValueAttribute : Attribute
    {
        public string ValueName { set; get; }
    }
}
