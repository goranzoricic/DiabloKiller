using UnityEngine;
using System.Collections;

namespace DiabloKiller {
    public class LootManager : Updateable {
        private float spawnTime = -1.0f;
        private Vector3 spawnTarget = new Vector3(0, 0, -5);
        GameObject healthPrefab = null;

        public static LootManager Instance {
            get { return Singleton<LootManager>.Instance; }
            private set { }
        }

        public LootManager() {
            healthPrefab = (GameObject)Resources.Load("Prefabs/Pickups/HealthPickup");
            //EventManager.Instance.AddEventListener("EnemyDied", OnEnemyDied);
        }

        // Update is called once per frame
        public override void Update() {
            //Debug.Log("[LootManager.Update] update executed");
            if (spawnTime >= 0.0f && spawnTime < Time.time) {
                GameObject.Instantiate(healthPrefab, spawnTarget, Quaternion.identity);
                spawnTime = -1.0f;
            }
        }

        public void QueueLoot(Transform target) {
            spawnTime = Time.time;
            spawnTarget = target.position;
        }

        public void OnEnemyDied(EventData eventData) {
            spawnTime = 3.0f;
        }

    }
}
