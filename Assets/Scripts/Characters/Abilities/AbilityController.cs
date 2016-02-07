using UnityEngine;
using System.Collections.Generic;

namespace DiabloKiller {
    public class AbilityController {
        private Dictionary<string, Ability> abilities;
 //       private Character owner;

        public AbilityController(Character owningCharacter) {
   //         owner = owningCharacter;
            abilities = new Dictionary<string, Ability>();
        }

        public void AddAbility(string slot, Ability ability) {
            abilities[slot] = ability;
        }

        // Update is called once per frame
        public void Update() {
        }

        public void UseAbility(string abilityName) {
            Ability ability = abilities[abilityName];
            if (ability == null) {
                Debug.LogErrorFormat("[AbilityController.UseAbility] Character attemted to use an ability it doesn't have: {0}", abilityName);
                return;
            }
            ability.Start();
        }

        public void OnDeath() {
        }

        public Ability GetAbilityFromInput() {
            Ability abilityFromInput = null;

            // select the ability the player used, based on the current state of inputs
            // note that this implementation also implicitly implements ability priorities, in the sense that if two controlls are pressed
            // at the same time, first one found by the ifs will be selected for use
            // this means that if the user moves by holding the left mouse button and then uses some other ability, 
            // the new ability will be executed 
            if (Input.GetButton("Ability04")) {
                abilityFromInput = abilities["Ability04"];
            } else if (Input.GetButton("Ability03")) {
                abilityFromInput = abilities["Ability03"];
            } else if (Input.GetButton("Ability02")) {
                abilityFromInput = abilities["Ability02"];
            } else if (Input.GetButton("Ability01")) {
                abilityFromInput = abilities["Ability01"];
            } else if (Input.GetButton("Secondary")) {
                abilityFromInput = abilities["Secondary"];
            } else if (Input.GetButton("Primary")) {
                abilityFromInput = abilities["Primary"];
            }

            return abilityFromInput;
        }
    };

}
