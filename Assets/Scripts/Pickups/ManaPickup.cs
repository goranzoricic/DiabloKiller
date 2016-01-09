﻿using UnityEngine;
using System.Collections;

public class ManaPickup : Pickup
{
    public int ManaAmmount;

    public override void OnTriggerEnter(Collider other)
    {
        if (!CanPickup(other)) {
            return;
        }

        Debug.LogFormat("[ManaPickup.OnTriggerEnter] Mana received by {0}, ammount: {1}", other.gameObject.name, ManaAmmount);
        base.OnTriggerEnter(other);

		PlayerCharacter character = other.GetComponent<PlayerCharacter> ();
		character.CharacterStats().ReceiveMana(ManaAmmount);
    }
}
