using UnityEngine;
using System.Collections;

public class PlayerCharacter : Character {
	
	// Use this for initialization
	void Start () {
		navMeshAgent = gameObject.GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (movementAllowed != true) {
            navMeshAgent.Stop();
            // rotate cylinder on death
            Transform t = gameObject.transform;
			t.Rotate (90f, 0f, 0f);
			return;
		}
		
		if (navMeshAgent == null) {
			return;
		}
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Input.GetButton("Fire1")) {
			if (Physics.Raycast(ray, out hit, 100))	{
				if (!hit.collider.CompareTag("Player")) {
					navMeshAgent.destination = hit.point;
					navMeshAgent.Resume();
				}
			}
		}
		
		if (navMeshAgent.remainingDistance <= MinDistance) {
			navMeshAgent.Stop();
		}
	} 
	
	public override void onDeath(){
		movementAllowed = false;
		
		Renderer renderer = gameObject.GetComponent<Renderer> ();
		renderer.material.color = Color.red;
	}
	
}
