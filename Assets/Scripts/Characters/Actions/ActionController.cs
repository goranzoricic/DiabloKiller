using UnityEngine;
using System.Collections.Generic;

namespace DiabloKiller {
    public class ActionController {

        // ----------------------- Class Fields -------------------------

        private Action currentAction;
        private Character owner;

        // Actions queued for execution (FIFO)
        private Queue<Action> actionQueue;

        // ----------------------- Constructors -------------------------

        public ActionController(Character owningCharacter) {
            owner = owningCharacter;
            actionQueue = new Queue<Action>();
        }

        // ----------------------- Public methods -------------------------

        // Update is called once per frame
        public void Update() {
            if (currentAction != null) {
                switch (currentAction.State()) {
                    case ActionState.Queued:
                        currentAction.Execute();
                        break;
                    case ActionState.Running:
                        {
                            // TODO Dino: think do we need to drive action update from here, 
                            // for now I'm inclined to think that actions should not have updates, but we'll see
                            break;
                        }
                    case ActionState.CompletedSuccess:
                    case ActionState.CompletedFail:
                        {
                            currentAction.Finish();
                            // Debug.Log("[ActionController.Update] action completed: " + currentAction.GetType());
                            ExecuteNextAction();
                            break;
                        }
                    default:
                        {
                            Debug.LogError("[ActionController.Update] Invalid action result in action controller");
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

        public void ExecuteAction(Action newAction) {
            if (currentAction != null) {
                currentAction.Interrupt();
                currentAction = null;
            }
            actionQueue.Clear();
            QueueAction(newAction);
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
}
