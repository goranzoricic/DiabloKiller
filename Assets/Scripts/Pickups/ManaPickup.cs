using UnityEngine;
using System.Collections;

public class ManaPickup : Pickup
{
    public long ManaAmmount;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnTriggerEnter(Collider other)
    {
        Debug.LogFormat("Mana received by {0}, ammount: {1}", other.gameObject.name, ManaAmmount);
        base.OnTriggerEnter(other);

		CharacterResources characterResources = other.GetComponent<CharacterResources> ();
		characterResources.ReceiveMana (ManaAmmount);
		
		Debug.LogFormat("Current Mana: {0}", characterResources.mana);
    }
}
