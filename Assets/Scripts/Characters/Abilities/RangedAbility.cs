using UnityEngine;
using System.Collections;

public class RangedAbility : Ability {
	Vector3 targetPoint;
	
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
    
    public override bool CanCastOnCharacter(Character targetCharacter) {
        if (targetCharacter.tag == "Enemy") {
            return true;
        }
        return false;
    }

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
