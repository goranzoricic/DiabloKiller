using UnityEngine;
using System.Collections;

namespace DiabloKiller {
    public class PlayerActionUseAbility : PlayerAction {
        private Ability ability;
        private bool forceStillCast = false;

        public PlayerActionUseAbility(Character owningCharacter, Ability usedAbility, bool shouldForceStillCast) : base(owningCharacter) {
            ability = usedAbility;
            forceStillCast = shouldForceStillCast;
        }

        public override void ProcessInput() {
        }


        // ----------------------- Virtual methods -------------------------

        protected override ActionState DoExecute() {
            ability.Start();
            owner.OnUseAbility(ability);
            return ActionState.CompletedSuccess;
        }

        protected override ActionState DoInterrupt() {
            return ActionState.CompletedSuccess;
        }
    }
}
