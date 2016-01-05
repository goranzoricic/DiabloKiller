using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

    public virtual void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

}
