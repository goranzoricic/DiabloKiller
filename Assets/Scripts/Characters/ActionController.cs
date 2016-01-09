using UnityEngine;
using System.Collections;

public class ActionController {
    private Action CurrentAction;
    private Character owner;

    public ActionController(Character owningCharacter) {
        owner = owningCharacter;
    } 

	// Update is called once per frame
	void Update () {
	    if (CurrentAction != null) {
            ActionResult result = CurrentAction.Update();
            switch (result) {
                case ActionResult.Completed_Fail :
                case ActionResult.Completed_Success : {
                        CurrentAction = null;
                        break;
                }
                case ActionResult.Continue : {
                        break;
                }
                default : {
                        Debug.LogError("Invalid action result in action controller");
                        break;
                }
            }
        }
	}

    void StartAction(Action newAction) {
        if (CurrentAction != null) {
            CurrentAction.Stop();
        }
        CurrentAction = newAction;
        CurrentAction.Start();
    }
};
