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
            EventManager.Instance.AddEventListener(CharacterEvents.CharacterStopped, OnCharacterStopped);
            owner.characterMovement.SetDestination(targetPoint);
            return ActionState.Running;
        }

        protected override ActionState DoInterrupt() {
            state = ActionState.CompletedSuccess;
            return state;
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
