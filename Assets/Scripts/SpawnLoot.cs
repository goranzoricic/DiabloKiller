using UnityEngine;
using System.Collections;

namespace DiabloKiller {
    public class SpawnLoot : MonoBehaviour {

        public static GameObject Spawn(Transform transform) {
            //Transform SpawnedObject = (Transform) Instantiate(SpawnTemplate, transform.position + offset, transform.rotation);
            //Pickup spawn = SpawnedObject.GetComponent<Pickup>();
            //spawn.SetSpawnMaster(this);

            GameObject instance = (GameObject)Instantiate(Resources.Load("Prefabs/Pickups/HealthPickup"), transform.position + new Vector3(2,0,0), Quaternion.identity);
            return instance;
        }
    }
}
