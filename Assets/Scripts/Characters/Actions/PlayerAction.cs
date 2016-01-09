using UnityEngine;
using System.Collections;

public class PlayerAction : Action {

    public PlayerAction(Character owningCharacter) : base(owningCharacter) {

    }

	// Use this for initialization
	public override void Start () {
	
	}

	// Update is called once per frame
    public override ActionResult Update() {
        return ActionResult.Completed_Fail;
    }


    public override void Stop() {
    }

    public virtual void ProcessInput() {

    }
}
