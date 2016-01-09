using UnityEngine;
using System.Collections;

public class PlayerActionUseAbility : PlayerAction {
	private Ability ability;
	private bool forceStillCast = false;

	public PlayerActionUseAbility(Character owningCharacter, Ability usedAbility, bool shouldForceStillCast) : base(owningCharacter) {
		ability = usedAbility;
		forceStillCast = shouldForceStillCast;
	}
	
	// Use this for initialization
	public override void Start () {
	
	}
	

	// Update is called once per frame
    public virtual ActionResult Update() {
        return ActionResult.Completed_Fail;
    }


    public override void Stop() {
    }

    public override void ProcessInput() {
    }    
}
