using UnityEngine;
using System.Collections;

namespace DiabloKiller {
    public class DamageAura : MonoBehaviour {
        public long DamagePerTick;
        public float DamageInterval;
        public float Duration = -1;

        public string DamageTargetTag;

        private float lastDamageTime;
        private float createdTime;

        void Start() {
            lastDamageTime = -DamageInterval;
            createdTime = Time.time;
        }

        // Update is called once per frame
        void Update() {
            float now = Time.time;
            if (lastDamageTime + DamageInterval < now) {
                Collider[] colliders = Physics.OverlapSphere(transform.position, transform.localScale.x/2);

                foreach (Collider collider in colliders) {
                    if (collider.tag != DamageTargetTag) {
                        continue;
                    }
                    Character character = collider.gameObject.GetComponent<Character>();
                    if (character != null) {
                        character.ReceiveDamage(DamagePerTick);
                    }
                }
                lastDamageTime = now;
            }
            if (Duration >= 0.0f && (createdTime + Duration) < now) {
                Destroy(gameObject);
            } 
        }

        private bool CanDamage(Collider other) {
            bool canDamage = false;
            if (other.gameObject.tag == DamageTargetTag) {
                canDamage = true;
            }
            return canDamage;
        }
    }
}
