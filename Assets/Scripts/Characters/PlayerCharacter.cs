using UnityEngine;
using System.Collections;

public class PlayerCharacter : Character {
	public Camera playerCamera;

	private NavMeshPath navPath;
	private Vector3 destination;
	private Rigidbody body;

	private const float maxPathingRatio = 1.5f;
	private bool useNavigation = true;

	private const float StopDelayAfterContact = 1.0f;
	private float LastContactTime = 0.0f;
	private bool stoppedDueToCollision = false;

	// Use this for initialization
	void Start () {
		navMeshAgent = gameObject.GetComponent<NavMeshAgent> ();
		navPath = new NavMeshPath();
		destination = transform.position;
		body = gameObject.GetComponent<Rigidbody>();
	}

	// Moves the character towards the last clicked location. Finds the navigation path to the target, but won't use it if
	// it is much longer than the linear distance to the destination. This is a copy of Diablo 3 movement, and the reasoning
	// is that the player has to guide the character around obstacles, while not requiring the player to be absolutely
	// precise while moving.
	void Move() {
		if (navMeshAgent == null) {
			return;
		}
		Ray ray = playerCamera.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Input.GetButton("Fire1")) {
			if (Physics.Raycast(ray, out hit, 100) && !hit.collider.CompareTag("Player")) {
				if ((destination - hit.point).magnitude > 0.1f) {
					stoppedDueToCollision = false;
					LastContactTime = float.MaxValue;
					useNavigation = false;
					destination = hit.point;
					NavMesh.CalculatePath(transform.position, destination, NavMesh.AllAreas, navPath);
					if (navPath.status == NavMeshPathStatus.PathComplete ) {
						float pathLength = PathLength(navPath);
						float distance = (transform.position - hit.point).magnitude;
						float pathRatio = (pathLength/distance)*(pathLength/distance);
						if (pathRatio < maxPathingRatio) {
							body.velocity = Vector3.zero;
							navMeshAgent.SetPath(navPath);
							navMeshAgent.Resume();
							useNavigation = true;
						} else {
							navMeshAgent.Stop();
						}
					}
				}
			}
		}
		
		if (!useNavigation && !stoppedDueToCollision) {
			// if hit a wall some time ago (don't stop immediately to make the character look like he tried and gave up)
			// stop the player
			if (LastContactTime + StopDelayAfterContact < Time.time) {
				body.velocity = Vector3.zero;
				destination = transform.position;
				stoppedDueToCollision = true;
			// if no wall was hit, move him directly to the destination
			} else {
				Vector3 direction = destination - transform.position;
				float distance = direction.magnitude;
				if (distance > 0.1f) {
					direction.Normalize();
					body.velocity = direction * navMeshAgent.speed;
				} else {
					body.velocity = Vector3.zero;
				}
			}
		} else if (stoppedDueToCollision) {
			destination = transform.position;
			body.velocity = Vector3.zero;
		}
	}

	// Update is called once per frame
	void Update () {
		if (movementAllowed != true) {
            navMeshAgent.Stop();
            destination = transform.position;
            body.velocity = Vector3.zero;
			return;
		}
		Move();		
	} 


	public virtual void OnTriggerEnter(Collider other)
	{
		if (!useNavigation && other.tag == "Wall") {
			LastContactTime = Time.time;
		}
	}


	public override void onDeath(){
		movementAllowed = false;

        // rotate cylinder on death
        Transform t = gameObject.transform;
        t.Rotate (90f, 0f, 0f);
		
		Renderer renderer = gameObject.GetComponent<Renderer> ();
		renderer.material.color = Color.red;
	}
	
}
