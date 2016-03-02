using UnityEngine;
using System.Collections;

namespace DiabloKiller {
    public class MeleeAbility : Ability {
        private Vector3 targetPoint;
        private Character targetCharacter;

        protected float range = 2.0f;

        public MeleeAbility(Character owningCharacter, string name) : base(owningCharacter, name) {
        }

        public override void SetTarget(Vector3 target) {
            targetPoint = target;
        }

        public override void SetTarget(Character target) {
            targetCharacter = target;
        }

        public override bool CanCastOnPoint(bool forceStillCast) {
            return forceStillCast;
        }

        public override bool CanCastOnCharacter(Character target, bool forceStillCast) {
            if (target.tag == "Enemy") {
                return true;
            }
            return false;
        }

        // Use this for initialization
        public override void Start(bool forceStillCast) {
            Debug.LogFormat("[MeleeAbility.Start] Using ability:  {0}", Name);
            if (forceStillCast) {
                Execute();
            } else {
                MoveToTargetAction action = new MoveToTargetAction(owner, targetCharacter.gameObject, range);
                action.SetCompleteCallback(OnTargetReached);
                owner.QueueAction(action);
            }
        }

        // Update is called once per frame
        public override void Update() {

        }

        protected void TurnToTarget() {
            Vector3 target = (targetCharacter != null) ? targetCharacter.transform.position : targetPoint;
            Vector3 direction = target - owner.transform.position;
            direction.y = 0;
            direction.Normalize();
            Quaternion rotation = Quaternion.LookRotation(direction);
            owner.transform.rotation = rotation;            
        }

        public virtual void Execute() {
            Debug.Log("[MeleeAbility.Execute]");
            TurnToTarget();

            if (targetCharacter != null) {
                targetCharacter.ReceiveDamage(100);
            }
        }

        private void OnTargetReached(bool success) {
            Debug.Log("[MeleeAbility.OnTargetReached]");
            if (success) {
                Execute();
            }
        }
    }
}
