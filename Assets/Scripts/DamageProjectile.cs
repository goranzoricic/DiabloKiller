using UnityEngine;
using System.Collections;

namespace DiabloKiller {
    public class DamageProjectile : Projectile {
        public long Damage;
        public string DamageTargetTag;

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        private bool CanDamage(GameObject gameObject) {
            bool canDamage = false;
            if (gameObject.tag == DamageTargetTag) {
                canDamage = true;
            }
            return canDamage;
        }

        public override void OnCollisionEnter(Collision hit) {
            if (CanDamage(hit.gameObject)) {
                CharacterResources resources = hit.gameObject.GetComponent<CharacterResources>();
                if (resources != null) {
                    resources.ReceiveDamage(Damage);
                } else { 
                    Debug.LogErrorFormat("Appliying damage to an invalid object: {0}", hit.gameObject.name);
                    return;
                }
            }

            base.OnCollisionEnter(hit);
        }
    }
}
