using System;
using System.Collections.Generic;

namespace Enigma
{
    [Entity(EntityName = "model")]
    public class ModelEntity : BaseModelEntity
    {
        private string _modelName;

        [Value(ValueName = "Model Name", Comment = "Full path to model", Type = ValueType.Model)]
        public string modelName 
        { 
            set
            {
                _modelName = value;
                editorModel = value;
            }
            get => _modelName;
        }
        [Value(ValueName = "Level of Detailization", Type = ValueType.List,
            Comment = "What minimal level of detailization need for render this model")]
        public int detailizationLevel;
        [Value(ValueName = "Fade Distance", Type = ValueType.Int,
            Comment = "Minimal distance between player and this model where model will didnt rendering\n" +
            " -1 = model render always")]
        public int fadeDistance;
        [Value(ValueName = "Draw Shadows", Type = ValueType.Boolean)]
        public bool drawShadows;

        public override void CreateInEditor()
        {
            base.CreateInEditor();
            modelName = "";
            detailizationLevel = 0;
            fadeDistance = -1;
            drawShadows = true;
        }
    }
}
