using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DiabloKiller {
    public class BuffController {
        private List<Buff> appliedBuffs;
        private Character owner;

        public BuffController(Character owningCharacter) {
            owner = owningCharacter;
            appliedBuffs = new List<Buff>();
        }

        // Update is called once per frame
        public void Update() {
            foreach (Buff buff in appliedBuffs) {
                buff.Update();
            }

            appliedBuffs.RemoveAll(buff => buff.HasExpired());
        }

        public void UseBuff(Buff buff) {
        }

        public void OnDeath() {
        }

    };
}
