using UnityEngine;
using System.Collections;

namespace DiabloKiller {
    public class DamagePickup : Pickup {
        public long DamageAmmount;

        public override void OnTriggerEnter(Collider other) {
            if (!CanPickup(other)) {
                return;
            }

            Debug.LogFormat("[DamagePickup.OnTriggerEnter] Damage received by {0}, ammount: {1}", other.gameObject.name, DamageAmmount);
            base.OnTriggerEnter(other);

            PlayerCharacter character = other.GetComponent<PlayerCharacter>();
            character.ReceiveDamage(DamageAmmount);
        }
    }
}
