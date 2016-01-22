using UnityEngine;
using System.Collections;


// Abilities control what a character can do. Their implementation consists of queuing actions through ActionController,
// with callbacks on certain events (e.g melee attack needs a MoveAction to complete if it is not in range of the target).
// Both players ane enemies use abilities.

// Example of Cleave as an ability
// - player clicks the LMB on an enemy
// - PlayerCharacter executes the 'LMB slot' ability through the AbilityController
// - CleaveAbility's Start() method is invoked
// - since the player is not in range, it runs a MoveToTargetAction through the ActionController, providing it with a MoveComplete callback
// - when the callback is invoked (with success/fail), runs a PlayAnimationAction to play the cleave's animation, with a AnimationEvent callback
// - when the cleave's animation fires the DoDamageNow event, the callback is invoked
// - the action collects all enemies affected by Cleave, creates a Damage object based on player stats and applies the damage to each enemy
namespace DiabloKiller {
    public class Ability {
        public string Name;

        private Character owner;

        public Ability(Character owningCharacter, string name) {
            owner = owningCharacter;
            Name = name;
        }

        public virtual bool CanCastOnPoint(bool ForceStillCast) {
            return false;
        }

        public virtual bool CanCastOnCharacter(Character targetCharacter) {
            return false;
        }

        public virtual bool CanCastOnSelf() {
            return false;
        }

        public virtual void SetTarget(Vector3 target) {

        }

        public virtual void SetTarget(Character target) {

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
