using UnityEngine;
using System.Collections;

public class SelfCastAbility : Ability {

    public SelfCastAbility(Character owningCharacter, string name) : base(owningCharacter, name) {
    }

    public override bool CanCastOnSelf() {
        return true;
    }

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
