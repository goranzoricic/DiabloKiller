using UnityEngine;
using System.Collections;

public class HealthPickup : Pickup {
    public long HealthAmmount;

    public override void OnTriggerEnter(Collider other)
    {
        if (!CanPickup(other)) {
            return;
        }

        Debug.LogFormat("Health received by {0}, ammount: {1}", other.gameObject.name, HealthAmmount);
        base.OnTriggerEnter(other);

		CharacterResources characterResources = other.GetComponent<CharacterResources> ();
		characterResources.ReceiveHealth (HealthAmmount);

		Debug.LogFormat("Current Health: {0}", characterResources.health);
    }
}
