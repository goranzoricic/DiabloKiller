using System.Collections;

// ----------------------- Public enums -------------------------

namespace DiabloKiller {

    public enum ActionState {
        Queued,
        Running,
        Completed
    };

    public enum ActionTypes {
        Instant,
        LongRunning,
    };

    public abstract class Action {

        // ----------------------- Class fields -------------------------

        private ActionState state = ActionState.Queued;
        private bool wasSuccess;

        protected Character owner;
        protected ActionTypes type = ActionTypes.Instant;

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
            if (state != ActionState.Queued) {
                throw new System.Exception("Wrong state (" + state + "). Only actions in Queued state can be executed.");
            }
            state = ActionState.Running;
            bool success = DoExecute();

            // if action type is Instant finish it imediatelly, otherwise wait for future Finish() method call
            if (type == ActionTypes.Instant) {
                doFinish(success);
            }
        }

        public void Interrupt() {
            if (state != ActionState.Running) {
                throw new System.Exception("Wrong state (" + state + "). Only actions in Running state can be interrupted.");
            }
            DoInterrupt();
            doFinish(false);
        }

        public void Finish(bool success) {
            if (state != ActionState.Running) {
                throw new System.Exception("Wrong state (" + state + "). Only actions in Running state can be finished.");
            }
            state = ActionState.Completed;
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
            state = ActionState.Completed;
            wasSuccess = success;
        }


    }

}
