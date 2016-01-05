using UnityEngine;
using System.Collections;

public class ManaPickup : Pickup
{
    public long ManaAmmount;

    public override void OnTriggerEnter(Collider other)
    {
        if (!CanPickup(other)) {
            return;
        }

        Debug.LogFormat("Mana received by {0}, ammount: {1}", other.gameObject.name, ManaAmmount);
        base.OnTriggerEnter(other);

		CharacterResources characterResources = other.GetComponent<CharacterResources> ();
		characterResources.ReceiveMana (ManaAmmount);
		
		Debug.LogFormat("Current Mana: {0}", characterResources.mana);
    }
}
