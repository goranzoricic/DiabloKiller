using System.Collections;

// ----------------------- Public enums -------------------------

public enum ActionState {
    NOT_STARTED,
    EXECUTING,
    COMPLETED
};

public enum ActionTypes {
    INSTANT,
    LONG_RUNNING,
};

public abstract class Action {

    // ----------------------- Class fields -------------------------

    private ActionState state = ActionState.NOT_STARTED;
    private bool wasSuccess;

    protected Character owner;
    protected ActionTypes type = ActionTypes.INSTANT;

    // ----------------------- Virtual methods -------------------------

    protected abstract bool DoExecute();
    protected abstract void DoInterrupt();
    protected abstract void ActionType();

    // ----------------------- Constructors methods -------------------------
    protected Action(Character owner) {
        this.owner = owner;
    }

    // ----------------------- Interface methods -------------------------

    public void Execute() {
        if (state != ActionState.NOT_STARTED) {
            throw new System.Exception("Wrong state (" + state + "). Only actions in NOT_STARTED state can be executed.");
        }
        state = ActionState.EXECUTING;
        bool success = DoExecute(); 
        
        // if action type is INSTANT finish it imediatelly, otherwise wait for future Finish() method call
        if (type == ActionTypes.INSTANT) {
            doFinish(success);
        }
    }

    public void Interrupt() {
        if (state != ActionState.EXECUTING) {
            throw new System.Exception("Wrong state (" + state + "). Only actions in EXECUTING state can be interrupted.");
        }
        DoInterrupt();
        doFinish(false);
    }

    public void Finish(bool success) {
        if (state != ActionState.EXECUTING ) {
            throw new System.Exception("Wrong state (" + state + "). Only actions in EXECUTING state can be finished.");
        }
        state = ActionState.COMPLETED;
        doFinish(success);
    }

    public bool WasSuccess() {
        return wasSuccess;
    }

    public ActionState State() {
        return state;
    }

    // ----------------------- Private methods -------------------------

    public void doFinish(bool success) {
        state = ActionState.COMPLETED;
        wasSuccess = success;
    }


}
