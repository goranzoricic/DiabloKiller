using UnityEngine;
using System.Collections;

namespace DiabloKiller {
    public class CharacterStat {
        CharacterStats stat;
        private int baseValue;
        private int currentValue;

        public CharacterStat(CharacterStats stat, int baseValue) {
            this.stat = stat;
            this.baseValue = baseValue;
        }

        public CharacterStats Stat {
            get { return stat; }
        }

        public int BaseValue {
            get { return baseValue; }
            set { baseValue = value; }
        }

        public int CurrentValue {
            get { return currentValue; }
            set { currentValue = value; }
        }
    }
}
