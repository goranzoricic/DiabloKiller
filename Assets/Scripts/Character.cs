using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour {

	[HideInInspector]
	public NavMeshAgent navMeshAgent;

	public float MinDistance = 0.01f;
	public float MovementSpeed = 3000f;

	public bool movementAllowed = true;

	// Use this for initialization
	void Start () {

	}

	public abstract void onDeath();

	protected float PathLength(NavMeshPath path) {
		if (path.corners.Length < 2)
			return 0;
		
		Vector3 previousCorner = path.corners[0];
		float lengthSoFar = 0.0F;
		int i = 1;
		while (i < path.corners.Length) {
			Vector3 currentCorner = path.corners[i];
			lengthSoFar += Vector3.Distance(previousCorner, currentCorner);
			previousCorner = currentCorner;
			i++;
		}
		return lengthSoFar;
	}

}
