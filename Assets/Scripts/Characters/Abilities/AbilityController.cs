using UnityEngine;
using System.Collections.Generic;

namespace DiabloKiller {
    public class AbilityController {
        private const float GLOBAL_COOLDOWN = 0.3f;

        private float nextAbilityTime = 0.0f;

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

        public bool IsAbilityReady(Ability ability) {
            if (IsOffGlobalCooldown()) {
                return true;
            }
            return false;
        }

        public void OnUseAbility(Ability ability) {
            StartGlobalCooldown();
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
            if (Input.GetButtonDown("Ability04")) {
                abilityFromInput = abilities["Ability04"];
            } else if (Input.GetButtonDown("Ability03")) {
                abilityFromInput = abilities["Ability03"];
            } else if (Input.GetButtonDown("Ability02")) {
                abilityFromInput = abilities["Ability02"];
            } else if (Input.GetButtonDown("Ability01")) {
                abilityFromInput = abilities["Ability01"];
            } else if (Input.GetButtonDown("Secondary")) {
                abilityFromInput = abilities["Secondary"];
            } else if (Input.GetButtonDown("Primary")) {
                abilityFromInput = abilities["Primary"];
            }

            return abilityFromInput;
        }

        private void StartGlobalCooldown() {
            nextAbilityTime = Time.time + GLOBAL_COOLDOWN;
        }

        private bool IsOffGlobalCooldown() {
            if (Time.time > nextAbilityTime) {
                return true;
            }
            return false;
        }
    };
}
