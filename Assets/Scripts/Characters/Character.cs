using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour {

	[HideInInspector]
	public NavMeshAgent navMeshAgent;

	public bool movementAllowed = true;

    private ActionController actionController;
    private AbilityController abilityController;
    private BuffController buffController;


    // Use this for initialization
    public virtual void Start () {
        Debug.LogFormat("[Character.Start] {0}", gameObject.name);
        actionController = new ActionController(this);
        abilityController = new AbilityController(this);
        buffController = new BuffController(this);
    }

    public virtual void Update() {
        actionController.Update();
        abilityController.Update();
        buffController.Update();
    }

    public virtual void OnDeath() {
        abilityController.OnDeath();
        actionController.OnDeath();
    }

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
