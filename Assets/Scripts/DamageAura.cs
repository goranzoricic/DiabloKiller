using UnityEngine;
using System.Collections;

namespace DiabloKiller {
    public class DamageAura : MonoBehaviour {
        public long DamagePerTick;
        public float DamageInterval;

        public string DamageTargetTag;

        private float LastDamageTime;
        private ArrayList ObjectsInArea = new ArrayList();
        ArrayList ToDelete = new ArrayList();

        // Update is called once per frame
        void Update() {
            float now = Time.time;
            if (LastDamageTime + DamageInterval >= now) {
                return;
            }
            foreach (Character character in ObjectsInArea) {
                if (character != null) {
                    character.CharacterSheet().ReceiveDamage(DamagePerTick);
                } else {
                    ToDelete.Add(character);
                }
            }
            foreach (CharacterResources resources in ToDelete) {
                ObjectsInArea.Remove(resources);
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

        public virtual void OnTriggerEnter(Collider other) {
            if (!CanDamage(other)) {
                return;
            }

            Character resource = other.gameObject.GetComponent<Character>();
            if (resource == null) {
                Debug.LogErrorFormat("Appliying damage to an invalid object: {0}", other.gameObject.name);
                return;
            }

            if (!ObjectsInArea.Contains(other.gameObject)) {
                ObjectsInArea.Add(resource);
            }
        }

        public virtual void OnTriggerExit(Collider other) {
            Character resource = other.gameObject.GetComponent<Character>();
            if (ObjectsInArea.Contains(resource)) {
                ObjectsInArea.Remove(resource);
            }
        }
    }
}
