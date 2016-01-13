using UnityEngine;
using System.Collections;


/**
 An action is one 'thing' a character can do: move to a point, use an ability, interact with an object.
 They are managed by an instance of ActionController, which is owned by a character.
 The action is responsible for performing any special tasks it needs to do upon completion, it should not rely on ActionController to
 handle that.
*/
public interface IAction {

    /**
        *  Exectues an action
        */
    void Execute();

    /**
        * This method interupts action in progress, all houskeeping should be done here 
    */
    void Interrupt();

    /**
        * This should be called when action is finished
        */
    void Finish(bool success);

    /**
        * Returns action state
        */
    ActionState State();

    /**
        * Returns action result
        */
    bool WasSuccess();

}
