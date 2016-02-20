using UnityEngine;
using System.Collections;

namespace DiabloKiller {
    public class Projectile : MonoBehaviour {

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        public virtual void OnCollisionEnter(Collision hit) {
            Destroy(gameObject);
        }
    }
}
