using UnityEngine;
using System.Collections;

namespace DiabloKiller {

    public class CharacterResource {
        CharacterResources resource;
        private long maxAmmount;
        private long currentAmmount;

        public CharacterResource(CharacterResources resource, long currentAmmount, long maxAmmount) {
            this.resource = resource;
            this.maxAmmount = maxAmmount;
            this.currentAmmount = currentAmmount;
        }

        public CharacterResources Resource {
            get { return resource; }
        }

        public long MaxAmmount {
            get { return maxAmmount; }
            set { maxAmmount = value; }
        }

        public long CurrentAmmount {
            get { return currentAmmount; }
            set { currentAmmount = value; }
        }
    }
}
