using UnityEngine;
using System.Collections;

namespace DiabloKiller {
	public class CharacterMovement {
        public bool MovementAllowed {
        	get { return movementAllowed; }
        	set { SetMovementAllowed(value); }
        }
        private bool movementAllowed;

        private Character owner;
	    private NavMeshAgent navMeshAgent;
        private Rigidbody body;

        private NavMeshPath navPath;
        private Vector3 destination;

        private const float stopDelayAfterContact = 1.0f;
        private float lastContactTime = 0.0f;
        private bool stoppedDueToCollision = false;

        private const float maxPathingRatio = 1.5f;
        private bool useNavigation = true;
        private bool moving = false;

        // ----------------------- Public Methods -------------------------
        public void Init() {
            movementAllowed = true;
            navMeshAgent = owner.navMeshAgent;
            navPath = new NavMeshPath();
            destination = owner.transform.position;
            body = owner.gameObject.GetComponent<Rigidbody>();
        }

        public void SetOwner(Character owner) {
            this.owner = owner;
        }

        private void Bind() {
        	navMeshAgent = owner.navMeshAgent;
        }

        private void SetMovementAllowed(bool allowed) {
        	movementAllowed = allowed;
            if (moving && !movementAllowed) {
                Stop(false, false);
            }
        }

        public virtual void OnTriggerEnter(Collider other) {
            if (!useNavigation && other.tag == "Wall") {
                lastContactTime = Time.time;
            }
        }

        public void SetDestination(Vector3 newDestination) {
            if (!MovementAllowed) {
                return;
            }

            if ((newDestination - destination).magnitude <= 0.1f) {
                return;
            }
            stoppedDueToCollision = false;
            lastContactTime = float.MaxValue;
            useNavigation = false;
            destination = newDestination;

            NavMesh.CalculatePath(owner.transform.position, destination, NavMesh.AllAreas, navPath);
            if (navPath.status == NavMeshPathStatus.PathComplete) {
                float pathLength = PathLength(navPath);
                float distance = (owner.transform.position - newDestination).magnitude;
                float pathRatio = (pathLength / distance) * (pathLength / distance);
                if (pathRatio < maxPathingRatio) {
                    body.velocity = Vector3.zero;
                    navMeshAgent.SetPath(navPath);
                    navMeshAgent.Resume();
                    useNavigation = true;
                } else {
                    navMeshAgent.Stop();
                }
            } else {
                // pathing was to slow - TODO: Fix this
                navMeshAgent.Stop();
            }
            moving = true;
        }

        // Moves the character towards the last clicked location. Finds the navigation path to the target, but won't use it if
        // it is much longer than the linear distance to the destination. This is a copy of Diablo 3 movement, and the reasoning
        // is that the player has to guide the character around obstacles, while not requiring the player to be absolutely
        // precise while moving.
        public void Update() {
            if (!MovementAllowed || !moving) {
                return;
            }
            if (navMeshAgent == null) {
                return;
            }
            Vector3 direction = destination - owner.transform.position;
            float distance = direction.magnitude;
            if (!useNavigation && !stoppedDueToCollision) {
                // if hit a wall some time ago (don't stop immediately to make the character look like he tried and gave up)
                // stop the player
                if (lastContactTime + stopDelayAfterContact < Time.time) {
                    Stop(false, true);
                    destination = owner.transform.position;
                    // if no wall was hit, move him directly to the destination
                } else {
                    if (distance > 0.1f) {
                        direction.Normalize();
                        body.velocity = direction * navMeshAgent.speed;
                    } else {
                        Stop(true, false);
                    }
                }
            } else if (stoppedDueToCollision) {
                Stop(false, true);
            } else if (distance <= 0.1f) {
                Stop(true, false);
            }
        }

        public void Stop(bool reachedDestination, bool dueToCollision) {
            body.velocity = Vector3.zero;
            destination = owner.transform.position;
            stoppedDueToCollision = dueToCollision;
            navMeshAgent.Stop();
            moving = false;
            EventManager.Instance.TriggerEvent(CharacterEvents.CharacterStopped, new EventDataBoolean(reachedDestination));
        }

        private float PathLength(NavMeshPath path) {
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
}
