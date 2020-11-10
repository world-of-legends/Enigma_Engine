using System;
using System.Collections.Generic;
using System.Text;

namespace Enigma
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ActionAttribute : Attribute
    {
        public string ActionName { set; get; }
    }
}
