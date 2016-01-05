using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {
    protected Spawner SpawnMaster;

    public virtual void OnTriggerEnter(Collider other)
    {
        if (SpawnMaster != null)
        {
            SpawnMaster.ObjectDestroyed(transform);
        }
        Destroy(gameObject);
    }

    protected bool CanPickup(Collider other)
    {
        return other.gameObject.tag == "Player";
    }

    public void SetSpawnMaster(Spawner master)
    {
        SpawnMaster = master;
    }
}
