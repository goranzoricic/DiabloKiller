using UnityEngine;
using System.Collections;
using System;

namespace DiabloKiller {
    public class PlayerAction : Action {

        public PlayerAction(Character owningCharacter) : base(owningCharacter) {

        }

        public virtual void ProcessInput() {

        }

        protected override bool DoExecute() {
            throw new NotImplementedException();
        }

        protected override void DoInterrupt() {
            throw new NotImplementedException();
        }

        protected override void ActionType() {
            throw new NotImplementedException();
        }
    }
}
