using UnityEngine;
using System.Collections;

namespace DiabloKiller {


    public class Projectile : MonoBehaviour {
        private Vector3 origin = new Vector3(0, 0, 0);
        private const float MAX_PROJECTILE_RANGE = 20;

        // Use this for initialization
        void Start() {
            origin = transform.position;
        }

        // Update is called once per frame
        void Update() { 
            float distanceTraveled = (transform.position - origin).magnitude;
            if (distanceTraveled > MAX_PROJECTILE_RANGE) {
                Destroy(gameObject);
            }
        }

        public virtual void OnCollisionEnter(Collision hit) {
            Destroy(gameObject);
        }
    }
}
