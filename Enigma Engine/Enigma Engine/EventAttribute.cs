using System;
using System.Collections.Generic;
using System.Text;

namespace Enigma
{
    [AttributeUsage(AttributeTargets.Event)]
    public class EventAttribute : Attribute
    {
        public string EventName { set; get; }
    }
}
