using UnityEngine;
using System.Collections;

namespace DiabloKiller {
    public class DamageAura : MonoBehaviour {
        public long DamagePerTick;
        public float DamageInterval;

        public string DamageTargetTag;

        private float LastDamageTime;
        private ArrayList ObjectsInArea = new ArrayList();

        // Update is called once per frame
        void Update() {
            float now = Time.time;
            if (LastDamageTime + DamageInterval >= now) {
                return;
            }

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
            LastDamageTime = now;
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
