using UnityEngine;
using System.Collections;

namespace DiabloKiller {
    public class SelfCastAbility : Ability {

        public SelfCastAbility(Character owningCharacter, string name) : base(owningCharacter, name) {
        }

        public override bool CanCastOnSelf() {
            return true;
        }

        // Use this for initialization
        public override void Start(bool forceStillCast) {

        }

        // Update is called once per frame
        public override void Update() {

        }
    }
}
