using System;

namespace Enigma
{
    public abstract class BaseModelEntity : BaseEntity
    {
        public string editorModel;
        [Value(ValueName = "Type of Physics", Type = ValueType.List)]
        public int physicsType;

        public override void CreateInEditor()
        {
            editorModel = "";
            physicsType = 0;
        }
    }
}
