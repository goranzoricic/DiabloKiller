using UnityEngine;
using System.Collections;

// ----------------------- Public enums -------------------------

namespace DiabloKiller {

    public enum ActionState {
        Queued,
        Running,
        CompletedSuccess,
        CompletedFail,
        Cancelled,
    };

    public enum ActionType {
        Instant,
        LongRunning,
    };

    public abstract class Action {
        // ----------------------- Properties -------------------------
        public ActionType ActionType {get; protected set;}

        // ----------------------- Class fields -------------------------

        protected ActionState state = ActionState.Queued;

        protected Character owner;

        // ----------------------- Virtual methods -------------------------

        protected abstract ActionState DoExecute();
        protected abstract ActionState DoInterrupt();

        // ----------------------- Constructors methods -------------------------
        protected Action(Character owner) {
            this.owner = owner;
        }

        // ----------------------- Interface methods -------------------------

        public void Execute() {
            if (state != ActionState.Queued) {
                throw new System.Exception("Wrong state (" + state + "). Only actions in Queued state can be executed.");
            }
            // Debug.Log("[Action.Execute] action executed: " + this.GetType());
            state = DoExecute();

            // if action type is Instant finish it imediatelly, otherwise wait for future Finish() method call
            // if (actionType == ActionType.Instant) {
            //     doFinish();
            // }
        }

        public void Interrupt() {
            if (state != ActionState.Running) {
                throw new System.Exception("Wrong state (" + state + "). Only actions in Running state can be interrupted.");
            }
            state = DoInterrupt();
            doFinish();
        }

        public ActionState State() {
            return state;
        }

        // ----------------------- Private methods -------------------------

        public void doFinish() {
            state = ActionState.CompletedSuccess;
        }
    }
}
