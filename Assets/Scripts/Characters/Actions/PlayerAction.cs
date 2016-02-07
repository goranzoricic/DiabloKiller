using UnityEngine;
using System.Collections;
using System;

namespace DiabloKiller {
    public abstract class PlayerAction : Action {

        public PlayerAction(Character owningCharacter) : base(owningCharacter) {

        }

        public virtual void ProcessInput() {

        }

        protected override ActionState DoExecute() {
            throw new NotImplementedException();
        }

        protected override ActionState DoInterrupt() {
            throw new NotImplementedException();
        }
    }
}
