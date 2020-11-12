using System;
using System.Collections.Generic;

namespace Enigma
{
    public abstract class BaseLogicEntity : BaseEntity
    {
        public string editorTexture;

        public override void CreateInEditor()
        {
            editorTexture = "";
        }
    }
}
