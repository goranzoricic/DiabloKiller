using UnityEngine;
using System.Collections.Generic;

public class ActionController {

    // ----------------------- Class Fields -------------------------

    private Action currentAction;
    private Character owner;

    // Actions queued for execution (FIFO)
    private Queue<Action> actionQueue;

    // ----------------------- Constructors -------------------------

    public ActionController(Character owningCharacter) {
        owner = owningCharacter;
    }

    // ----------------------- Public methods -------------------------

    // Update is called once per frame
    public void Update() {
        if (currentAction != null) {
            switch (currentAction.State()) {
                case ActionState.NOT_STARTED:
                    currentAction.Execute();
                    break;
                case ActionState.EXECUTING: {
                        // TODO Dino: think do we need to drive action update from here, 
                        // for now I'm inclined to think that actions should not have updates, but we'll see
                        break;
                    }
                case ActionState.COMPLETED: {
                        ExecuteNextAction();
                        break;
                    }
                default: {
                        Debug.LogError("[ActivityController.Update] Invalid action result in action controller");
                        break;
                    }
            }
        } else if (actionQueue.Count > 0) {
            currentAction = actionQueue.Dequeue();
            currentAction.Execute();
        }
    }

    /**
     * Queues action for execution
     */
    public void QueueAction(Action newAction) {
        actionQueue.Enqueue(newAction);
    }

    /**
     * Removes action from queue if it is not started yet, does nothing otherwise
     */
    public void RemoveActionFromQueue() {
        // TODO see if this method is needed - if yes, we need to implent queue through list then
    }

    // ----------------------- Private methods -------------------------

    private void ExecuteNextAction() {
        if (actionQueue.Count > 0) {
            currentAction = actionQueue.Dequeue();
            currentAction.Execute();
        } else {
            currentAction = null;
        }
    }
};
