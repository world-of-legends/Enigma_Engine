using Stride.Core.Mathematics;
using Stride.Engine;
using System;

namespace Enigma
{
    public abstract class BaseModelEntity : BaseEntity
    {
        public string editorModel;
        protected Entity modelEntity;

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
            modelEntity = new Entity();
            Stride.Rendering.Model mdl = new Stride.Rendering.Model();
            RuntimeLevel.renderer.LoadModel(editorModel, ref mdl);
            modelEntity.Add(new ModelComponent(mdl));
            base.Create(data);
        }
        public override void Destroy(ActionData data)
        {
            base.Destroy(data);
        }
    }
}
