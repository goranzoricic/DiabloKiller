using UnityEngine;
using System.Collections;


// Buffs are effectively event handlers registered on a character, that alter it's stats and behavior.
// Buffs encompass positive and negative modifiers (i.e. buffs and debuffs, as well as reactionary modifiers (x happens on crit/miss ...).
// They can be permanent or temporary, applied through various methods - use of abilities, being target of other's abilities, use of items, etc. 
namespace DiabloKiller {
    public class Buff {
        private Character owner;

        public Buff(Character owningCharacter) {
            owner = owningCharacter;
        }

        // Use this for initialization
        public virtual void Apply() {

        }

        // Update is called once per frame
        public virtual void Update() {

        }

        public virtual void Remove() {

        }

        public virtual bool HasExpired() {
            return false;
        }
    }
}
