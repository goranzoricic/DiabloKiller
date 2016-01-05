using UnityEngine;
using System.Collections;

public class DamagePickup : Pickup
{
    public long DamageAmmount;

    public override void OnTriggerEnter(Collider other)
    {
        if (!CanPickup(other)) {
            return;
        }

        Debug.LogFormat("Damage received by {0}, ammount: {1}", other.gameObject.name, DamageAmmount);
        base.OnTriggerEnter(other);

        CharacterResources characterResources = other.GetComponent<CharacterResources>();
        characterResources.ReceiveDamage(DamageAmmount);

        Debug.LogFormat("Current Health: {0}", characterResources.health);
    }
}
