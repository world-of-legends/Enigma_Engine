using System;

namespace Enigma
{
    public abstract class BaseEntity
    {
        [Value(ValueName = "Name of Entity")]
        public string name;

        /// <summary>
        /// Method called when new empty entity creating in Editor
        /// </summary>
        public abstract void CreateInEditor();
    }
}
