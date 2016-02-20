using UnityEngine;
using System.Collections;

namespace DiabloKiller {
    public class EnemyCharacter : Character {

        GameObject player;

        // Use this for initialization
        public override void Start() {
            base.Start();
            navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
            player = GameObject.FindGameObjectWithTag("Player");
            EnemyManager.Instance.AddEnemy(this);
        }

        // Update is called once per frame
        public override void Update() {
            base.Update();

            if (MovementAllowed != true) {
                return;
            }

            if (navMeshAgent == null) {
                return;
            }

            if (player) {
                navMeshAgent.destination = player.transform.position;
                navMeshAgent.Resume();
            }
        }

        public override void OnDeath() {
            base.OnDeath();
            MovementAllowed = false;
            LootManager.Instance.QueueLoot(transform);
            Destroy(gameObject);
        }

    }
}
