using UnityEngine;
using System.Collections;

public class ActionController {
    private Action currentAction;
    private Character owner;

    public ActionController(Character owningCharacter) {
        owner = owningCharacter;
    }

    // Update is called once per frame
    public void Update () {
	    if (currentAction != null) {
            ActionResult result = currentAction.Update();
            switch (result) {
                case ActionResult.Completed_Fail :
                case ActionResult.Completed_Success : {
                        currentAction = null;
                        break;
                }
                case ActionResult.Continue : {
                        break;
                }
                default : {
                        Debug.LogError("[ActivityController.Update] Invalid action result in action controller");
                        break;
                }
            }
        }
	}

    public void StartAction(Action newAction) {
        if (currentAction != null) {
            currentAction.Stop();
        }
        currentAction = newAction;
        currentAction.Start();
    }
    public void OnDeath() {
    }

};
