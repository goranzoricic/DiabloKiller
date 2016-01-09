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
public class Ability {
    private Character owner;

    public Ability(Character owningCharacter) {
        owner = owningCharacter;
    }

    // Use this for initialization
    public void Start() {
	
	}

    // Update is called once per frame
    public void Update () {
	
	}

    public void Stop() {

    }
}
