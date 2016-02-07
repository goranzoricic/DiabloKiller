using UnityEngine;
using System.Collections;

namespace DiabloKiller {
    public class SpawnLoot : MonoBehaviour {

        public static GameObject Spawn() {
            //Transform SpawnedObject = (Transform) Instantiate(SpawnTemplate, transform.position + offset, transform.rotation);
            //Pickup spawn = SpawnedObject.GetComponent<Pickup>();
            //spawn.SetSpawnMaster(this);

            GameObject instance = (GameObject)Instantiate(Resources.Load("HealthPickup"));
            return instance;
        }
    }
}
