using UnityEngine;
using System.Collections;
using System;

namespace DiabloKiller {
    public class MoveToPointAction : Action {
        private Vector3 targetPoint;

        public MoveToPointAction(Character owner, Vector3 targetPoint) : base(owner) {
            this.targetPoint = targetPoint;
        }

        protected override ActionState DoExecute() {
            EventManager.Instance.AddEventListener("CharacterStopped", OnCharacterStopped);
            owner.characterMovement.SetDestination(targetPoint);
            return ActionState.Running;
        }

        protected override ActionState DoInterrupt() {
            throw new NotImplementedException();
        }

        public void OnCharacterStopped(EventData eventData) {
            if (((EventDataBoolean)eventData).Value) {
                state = ActionState.CompletedSuccess;
            } else {
                state = ActionState.CompletedFail;
            }
        }
    }
}
