using System;
using System.Collections.Generic;

namespace Enigma
{
    public abstract class BaseFigureEntity : BaseEntity
    {
        public Figure editorFigure;

        public override void CreateInEditor()
        {
            //pass
        }

        public override void Destroy(ActionData data)
        {
            base.Destroy(data);
        }
    }
}
