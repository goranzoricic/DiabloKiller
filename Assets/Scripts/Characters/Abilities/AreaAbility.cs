using UnityEngine;
using System.Collections;

namespace DiabloKiller {
    public class AreaAbility : Ability {
        Vector3 targetPoint;

        public AreaAbility(Character owningCharacter, string name) : base(owningCharacter, name) {
        }

        public virtual void SetTarget(Vector3 target) {
            targetPoint = target;
        }

        public virtual void SetTarget(Character target) {
            targetPoint = target.transform.position;
        }

        public virtual bool CanCastOnPoint(bool ForceStillCast) {
            return true;
        }

        public virtual bool CanCastOnCharacter(Character targetCharacter) {
            return true;
        }

        // Use this for initialization
        public virtual void Start() {

        }

        // Update is called once per frame
        public virtual void Update() {

        }

        public virtual void Stop() {

        }
    }
}
