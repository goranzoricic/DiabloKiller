using UnityEngine;
using System.Collections;

public class HealthPickup : Pickup {
    public long HealthAmmount;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void OnTriggerEnter(Collider other)
    {
        Debug.LogFormat("Health received by {0}, ammount: {1}", other.gameObject.name, HealthAmmount);
        base.OnTriggerEnter(other);

		CharacterResources characterResources = other.GetComponent<CharacterResources> ();
		characterResources.ReceiveHealth (HealthAmmount);

		Debug.LogFormat("Current Health: {0}", characterResources.health);
    }
}
