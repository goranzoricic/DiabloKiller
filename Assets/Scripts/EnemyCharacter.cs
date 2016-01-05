using UnityEngine;
using System.Collections;

public class EnemyCharacter : Character {

	GameObject player;

	// Use this for initialization
	void Start () {
		navMeshAgent = gameObject.GetComponent<NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		if (movementAllowed != true) {
			// rotate cylinder on death
			Transform t = gameObject.transform;
			t.Rotate (90f, 0f, 0f);
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

	public override void onDeath(bool shouldMove){
		movementAllowed = shouldMove;

		//Renderer renderer = gameObject.GetComponent<Renderer> ();
		//renderer.material.color = Color.red;
	}

}
