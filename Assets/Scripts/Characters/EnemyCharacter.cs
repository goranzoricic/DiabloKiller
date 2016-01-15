using UnityEngine;
using System.Collections;

public class EnemyCharacter : Character {

	GameObject player;

    // Use this for initialization
    public override void Start () {
        base.Start();
		navMeshAgent = gameObject.GetComponent<NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	public override void Update () {

		if (movementAllowed != true) {
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

	public override void OnDeath(){
		movementAllowed = false;

        // rotate cylinder on death
        Transform t = gameObject.transform;
        t.Rotate (90f, 0f, 0f);
		Renderer renderer = gameObject.GetComponent<Renderer> ();
		renderer.material.color = Color.red;

		// spawn health pickup when enemy dies
		Vector3 newPosition = t.position;
		GameObject newObject = SpawnLoot.Spawn ();
		newObject.transform.position = newPosition;

		Destroy (t.gameObject);
	}

}
