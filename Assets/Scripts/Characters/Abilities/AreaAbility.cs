using UnityEngine;
using System.Collections;

namespace DiabloKiller {
    public class AreaAbility : Ability {
        Vector3 targetPoint;

        public AreaAbility(Character owningCharacter, string name) : base(owningCharacter, name) {
        }

        public override void SetTarget(Vector3 target) {
            targetPoint = target;
        }

        public override void SetTarget(Character target) {
            targetPoint = target.transform.position;
        }

        public override bool CanCastOnPoint(bool ForceStillCast) {
            return true;
        }

        public override bool CanCastOnCharacter(Character targetCharacter) {
            return true;
        }

        // Use this for initialization
        public override void Start() {

        }

        // Update is called once per frame
        public override void Update() {

        }

        public override void Stop() {

        }
    }
}
