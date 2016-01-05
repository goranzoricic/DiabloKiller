using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public virtual void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

}
