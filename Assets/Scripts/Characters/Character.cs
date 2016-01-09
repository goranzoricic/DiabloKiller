using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour {

	[HideInInspector]
	public NavMeshAgent navMeshAgent;

	public bool movementAllowed = true;

    private ActionController actionController;

	// Use this for initialization
	public virtual void Start () {
        actionController = new ActionController(this);
    }

    public virtual void Update() {
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
