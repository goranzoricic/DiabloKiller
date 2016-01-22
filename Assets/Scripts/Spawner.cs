using UnityEngine;
using System.Collections;
using System;

namespace DiabloKiller {
    public class Spawner : MonoBehaviour {
        public float SpawnTime;
        public bool Repeat;
        public Transform SpawnTemplate;

        private bool SpawnedOnce;
        private float LastSpawnTime;
        private static Vector3 offset = new Vector3(0, -0.5f, 0);

        private Transform SpawnedObject;

        // Use this for initialization
        void Awake() {
            SpawnedOnce = false;
            LastSpawnTime = 0.0f;
        }

        // Notification that the spawned object was destroyed
        public void ObjectDestroyed(Transform transform) {
            LastSpawnTime = Time.time;
            SpawnedObject = null;
        }

        // Update is called once per frame
        void Update() {
            if (SpawnedObject != null) {
                return;
            }
            if (!Repeat && SpawnedOnce) {
                return;
            }
            float now = Time.time;
            if (LastSpawnTime + SpawnTime >= now) {
                return;
            }

            SpawnedObject = (Transform)Instantiate(SpawnTemplate, transform.position + offset, transform.rotation);
            Pickup pickup = SpawnedObject.GetComponent<Pickup>();
            pickup.SetSpawnMaster(this);
            SpawnedOnce = true;
            LastSpawnTime = now;
        }
    }

}
