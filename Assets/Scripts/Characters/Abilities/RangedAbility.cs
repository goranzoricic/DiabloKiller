using UnityEngine;
using System.Collections;

namespace DiabloKiller {
    public abstract class RangedAbility : Ability {
        protected Vector3 targetPoint;
        
        public RangedAbility(Character owningCharacter, string name) : base(owningCharacter, name) {
        }

        public override void SetTarget(Vector3 target) {
            targetPoint = target;
        }

        public override void SetTarget(Character target) {
            targetPoint = target.transform.position;
        }

        public override bool CanCastOnPoint(bool forceStillCast) {
            return forceStillCast;
        }

        public override bool CanCastOnCharacter(Character targetCharacter, bool forceStillCast) {
            if (targetCharacter.tag == "Enemy") {
                return true;
            }
            return forceStillCast;
        }

        // Use this for initialization
        public override void Start(bool forceStillCast) {
            Debug.Log("[RangedAbility.Start]");

        }

        // Update is called once per frame
        public override void Update() {

        }
    }
}
