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
            MovementAllowed = false;

            // rotate cylinder on death
            Transform t = gameObject.transform;
            t.Rotate(90f, 0f, 0f);
            Renderer renderer = gameObject.GetComponent<Renderer>();
            renderer.material.color = Color.red;

            // spawn health pickup when enemy dies
            Vector3 newPosition = t.position;
            GameObject newObject = SpawnLoot.Spawn();
            newObject.transform.position = newPosition;

            Destroy(t.gameObject);
        }

    }
}
