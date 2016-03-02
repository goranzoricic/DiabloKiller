using UnityEngine;
using System.Collections;

namespace DiabloKiller {
    public class MoveToTargetAction : Action {
        private GameObject targetObject;
        private float range;
        private System.Action<bool> completeCallback;

        public MoveToTargetAction(Character owner, GameObject targetObject, float range = 2.0f) : base(owner) {
            this.targetObject = targetObject;
            this.range = range;
            completeCallback = null;
        }

        public void SetCompleteCallback(System.Action<bool> callback) {
        	completeCallback = callback;
        }

        protected override ActionState DoExecute() {
            EventManager.Instance.AddEventListener(CharacterEvents.CharacterStopped, OnCharacterStopped);
            owner.characterMovement.SetDestination(targetObject, range);
            return ActionState.Running;
        }

        protected override ActionState DoInterrupt() {
            state = ActionState.CompletedSuccess;
            return state;
        }

        protected override ActionState DoFinish() {
            EventManager.Instance.RemoveEventListener(CharacterEvents.CharacterStopped, OnCharacterStopped);
            return state;
        }

        public void OnCharacterStopped(EventData eventData) {
            if (((EventDataBoolean)eventData).Value) {
            	if (completeCallback != null) {
            		completeCallback(true);
            	}
                state = ActionState.CompletedSuccess;
            } else {
                state = ActionState.CompletedFail;
            }
        }
    }
}
