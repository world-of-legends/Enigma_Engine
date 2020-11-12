using Stride.Core.Mathematics;
using Stride.Engine;
using System;

namespace Enigma
{
    public abstract class BaseModelEntity : BaseEntity
    {
        public string editorModel;
        private Entity modelEntity;

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
            modelEntity = new Entity();
        }
        public override void Create(ActionData data)
        {

            base.Create(data);
        }
        public override void Destroy(ActionData data)
        {
            base.Destroy(data);
        }
    }
}
