using System;
using System.Collections.Generic;

namespace Enigma
{
    [Entity(EntityName = "gameinfo")]
    public sealed class GameInfoEntity : BaseLogicEntity
    {
        public override void CreateInEditor()
        {
            base.CreateInEditor();
            name = "Game";
        }

        #region Events
        [Event(EventName = "OnFinish")]
        public event Action<ActionData> OnFinish;
        #endregion

        #region Actions
        [Action(ActionName = "Finish")]
        public void Finish(ActionData data)
        {
            //pass
        }
        [Action(ActionName = "LoadNewLevel")]
        public void LoadNewLevel(ActionData data)
        {
            //pass
        }
        #endregion
    }
}
