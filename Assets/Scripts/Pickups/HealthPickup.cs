using UnityEngine;
using System.Collections;

namespace DiabloKiller {
    public class HealthPickup : Pickup {
        public long HealthAmmount;

        public override void OnTriggerEnter(Collider other) {
            if (!CanPickup(other)) {
                return;
            }

            Debug.LogFormat("[HealthAmmount.OnTriggerEnter] Health received by {0}, ammount: {1}", other.gameObject.name, HealthAmmount);
            base.OnTriggerEnter(other);

            PlayerCharacter character = other.GetComponent<PlayerCharacter>();
            character.CharacterSheet().ReceiveHealth(HealthAmmount);
        }
    }
}
