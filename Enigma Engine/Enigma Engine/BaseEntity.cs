using System;

namespace Enigma
{
    public abstract class BaseEntity
    {
        #region Values
        [Value(ValueName = "Name of Entity")]
        public string name;
        #endregion

        #region Events
        [Event(EventName = "OnDestroy")]
        public event Action<ActionData> OnDestroy;
        #endregion

        /// <summary>
        /// Method called when new empty entity creating in Editor
        /// </summary>
        public abstract void CreateInEditor();
        public abstract void OnCreate();

        #region Actions
        [Action(ActionName = "Destroy")]
        public virtual void Destroy(ActionData data)
        {
            //delete this entity from global enteties
        }
        #endregion
    }
}
