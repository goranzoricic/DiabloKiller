using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {
	public float MinDistance = 0.01f;
	public float MovementSpeed = 3000f;

	private NavMeshAgent navMeshAgent;


	// Use this for initialization
	void Start () {
		navMeshAgent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
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
}
