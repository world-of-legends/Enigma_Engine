using Stride.Core.Mathematics;
using System;

namespace Enigma
{
    public abstract class BaseModelEntity : BaseEntity
    {
        public string editorModel;

        #region Values
        [Value(ValueName = "Type of Physics", Type = ValueType.List)]
        public int physicsType;
        [Value(ValueName = "Position", Type = ValueType.Position)]
        public Vector3 position;
        #endregion

        public override void CreateInEditor()
        {
            editorModel = "";
            physicsType = 0;
        }
        public override void OnCreate()
        {
            //pass
        }
        public override void Destroy(ActionData data)
        {
            base.Destroy(data);
        }
    }
}
