using UnityEngine;
using System.Collections;

namespace DiabloKiller {
    public class EnemyCharacter : Character {

        GameObject player;
        public LootTableType lootTableType;

        // Use this for initialization
        public override void Start() {
            base.Start();
            navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
            player = GameObject.FindGameObjectWithTag("Player");

            // create enemy stats
            CharacterStat power = new CharacterStat(CharacterStats.Power, 10);
            characterSheet.AddStat(CharacterStats.Strength, power);
            // create enemy resources
            CharacterResource health = new CharacterResource(CharacterResources.Health, 20, 20);
            characterSheet.AddResource(CharacterResources.Health, health);

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

            Debug.LogFormat("[EnemyCharacter.OnDeath]");

            MovementAllowed = false;
            LootManager.Instance.QueueLoot(transform);
            Destroy(gameObject);
        }

    }
}
