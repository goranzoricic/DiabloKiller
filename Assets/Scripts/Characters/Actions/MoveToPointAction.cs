using UnityEngine;
using System.Collections;
using System;

public class MoveToPointAction : Action {
	private Vector3 targetPoint;

    public MoveToPointAction(Character owner, Vector3 targetPoint) : base(owner) {
        
    }

    protected override bool DoExecute() {
        throw new NotImplementedException();
    }

    protected override void DoInterrupt() {
        throw new NotImplementedException();
    }

    protected override void ActionType() {
        type = ActionTypes.LONG_RUNNING;
    }
}
