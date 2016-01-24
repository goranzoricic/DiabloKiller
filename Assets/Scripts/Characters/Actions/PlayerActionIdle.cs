using UnityEngine;
using System.Collections;

namespace DiabloKiller {
    public class PlayerActionIdle : PlayerAction {

        public PlayerActionIdle(Character owningCharacter) : base(owningCharacter) {

        }

        public override void ProcessInput() {
            Ability usedAbility = owner.GetUsedAbility();

            if (usedAbility == null) {
                return;
            }

            Action newAction = null;
            if (usedAbility.CanCastOnSelf()) {
                newAction = new PlayerActionUseAbility(owner, usedAbility, false);
            } else {
                bool forceStillCast = Input.GetButton("ForceStillCast");
                Ray ray = ((PlayerCharacter)owner).PlayerCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool hitSomething = Physics.Raycast(ray, out hit, 100) && !hit.collider.CompareTag("Player");
                if (hitSomething) {
                    if (hit.collider.CompareTag("Floor") && usedAbility.CanCastOnPoint(forceStillCast)) {
                        usedAbility.SetTarget(hit.point);
                        newAction = new PlayerActionUseAbility(owner, usedAbility, forceStillCast);
                    } else if (hit.collider.CompareTag("Enemy") && usedAbility.CanCastOnCharacter(hit.collider.gameObject.GetComponent<Character>())) {
                        Character target = hit.collider.gameObject.GetComponent<Character>();
                        usedAbility.SetTarget(target);
                        newAction = new PlayerActionUseAbility(owner, usedAbility, forceStillCast);
                    } else {
                        newAction = new MoveToPointAction(owner, hit.point);
                    }
                }
            }

            if (newAction != null) {
                owner.StartAction(newAction);
            }
        }
    }
}
