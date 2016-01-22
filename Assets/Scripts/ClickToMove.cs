using UnityEngine;
using System.Collections;

namespace DiabloKiller {
    public class ClickToMove : MonoBehaviour {
        public float MinDistance = 0.01f;
        public float MovementSpeed = 3000f;

        private NavMeshAgent navMeshAgent;

        private bool movementAllowed = true;


        // Use this for initialization
        void Start() {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update() {
            if (movementAllowed != true) {
                // rotate cylinder on death
                Transform t = gameObject.transform;
                t.Rotate(90f, 0f, 0f);
                return;
            }

            if (navMeshAgent == null) {
                return;
            }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Input.GetButton("Fire1")) {
                if (Physics.Raycast(ray, out hit, 100)) {
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

        public void onDeath(bool shouldMove) {
            movementAllowed = shouldMove;

            Renderer renderer = gameObject.GetComponent<Renderer>();
            renderer.material.color = Color.red;
        }

    }
}
