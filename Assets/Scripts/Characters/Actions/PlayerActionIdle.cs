using UnityEngine;
using System.Collections;

namespace DiabloKiller {
    public class PlayerActionIdle : PlayerAction {

        public PlayerActionIdle(Character owningCharacter) : base(owningCharacter) {

        }


        // ----------------------- Virtual methods -------------------------

        protected virtual ActionState DoExecute() {
            return ActionState.Running;
        }

        protected virtual ActionState DoInterrupt() {
            return ActionState.CompletedSuccess;
        }
    }
}
