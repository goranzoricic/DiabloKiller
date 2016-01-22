using UnityEngine;
using System.Collections;

namespace DiabloKiller {
    public class CharacterStats : MonoBehaviour {

        private Character owner;

        // base stats
        private int strength = 10;
        private int agility = 10;
        private int inteligance = 10;
        private int vitality = 10;

        public int Strength {
            get { return strength; }
            set { strength = value; }
        }

        public int Agility {
            get { return agility; }
            set { agility = value; }
        }

        public int Inteligence {
            get { return inteligance; }
            set { inteligance = value; }
        }

        public int Vitality {
            get { return vitality; }
            set { vitality = value; }
        }

        // ----------------------- Public methods -------------------------
        public void SetOwner(Character owner) {
            this.owner = owner;
        }



        // ----------------------- Private methods -------------------------


    }
}
