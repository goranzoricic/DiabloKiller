using System.Collections;


public enum ActionResult {
    Continue,
    Completed_Success,
    Completed_Fail
};


// An action is one 'thing' a character can do: move to a point, use an ability, interact with an object.
// They are managed by an instance of ActionController, which is owned by a character.
// It will update an action, letting it perform its job, until completion. The action is responsible for
// performing any special tasks it needs to do upon completion, it should not rely on ActionController to
// handle that.

public class Action {
    public void Start() {
    }

    public ActionResult Update() {
        return ActionResult.Completed_Fail;
    }

    public void Stop() {

    }
}
