using System;
using System.Collections.Generic;

namespace Enigma
{

    [AttributeUsage(AttributeTargets.Class)]
    public class EntityAttribute : Attribute
    {    
        public string EntityName { set; get; }
    }
}
