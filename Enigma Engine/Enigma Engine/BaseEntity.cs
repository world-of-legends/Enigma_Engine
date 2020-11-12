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

        #region Actions
        [Action(ActionName = "Destroy")]
        public virtual void Destroy(ActionData data)
        {
            RuntimeLevel.entities.Remove(this);
        }

        [Action(ActionName = "Create")]
        public virtual void Create(ActionData data)
        {
            RuntimeLevel.entities.Add(this);
        }
        #endregion
    }
}
