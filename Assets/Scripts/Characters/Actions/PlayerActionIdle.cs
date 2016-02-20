using UnityEngine;
using System.Collections;

namespace DiabloKiller {
    public class PlayerActionIdle : PlayerAction {

        public PlayerActionIdle(Character owningCharacter) : base(owningCharacter) {

        }


        // ----------------------- Virtual methods -------------------------

        protected override ActionState DoExecute() {
            return ActionState.Running;
        }

        protected override ActionState DoInterrupt() {
            return ActionState.CompletedSuccess;
        }
    }
}
