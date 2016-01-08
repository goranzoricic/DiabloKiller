using UnityEngine;
using System.Collections;

public class SpawnLoot : MonoBehaviour {

	private static Vector3 offset = new Vector3(0, -0.5f, 0);

	public static GameObject Spawn() {
		 
		//Transform SpawnedObject = (Transform) Instantiate(SpawnTemplate, transform.position + offset, transform.rotation);
		//Pickup spawn = SpawnedObject.GetComponent<Pickup>();
		//spawn.SetSpawnMaster(this);

		GameObject instance = (GameObject)Instantiate(Resources.Load("HealthPickup"));
		return instance;
	}
}
