using UnityEngine;
using System.Collections;

public class HealthPickup : Pickup {
    public long HealthAmmount;

    public override void OnTriggerEnter(Collider other)
    {
        if (!CanPickup(other)) {
            return;
        }

        Debug.LogFormat("[HealthAmmount.OnTriggerEnter] Health received by {0}, ammount: {1}", other.gameObject.name, HealthAmmount);
        base.OnTriggerEnter(other);

        PlayerCharacter character = other.GetComponent<PlayerCharacter>();
        character.CharacterStats().ReceiveHealth (HealthAmmount);
    }
}
