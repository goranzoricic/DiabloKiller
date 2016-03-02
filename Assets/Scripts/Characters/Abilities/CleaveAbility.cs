using UnityEngine;
using System.Collections;

namespace DiabloKiller {
	public class CleaveAbility : MeleeAbility {
		static private Object areaPrefab;

        public CleaveAbility(Character owningCharacter, string name) : base(owningCharacter, name) {
        	if (areaPrefab == null) {
        		areaPrefab = Resources.Load("Prefabs/CleaveArea");
        	}
        }


        // Use this for initialization
        public override void Start(bool forceStillCast) {
            Debug.Log("[CleaveAbility.Start]");
            base.Start(forceStillCast);
        }

        public override void Execute() {
            Debug.Log("[CleaveAbility.Execute]");
            TurnToTarget();

            Vector3 direction = owner.transform.forward;
            direction.y = owner.transform.position.y + 1.0f;
            direction.Normalize();
            Vector3 position = owner.transform.position + direction * range;

			GameObject area = (GameObject)GameObject.Instantiate(areaPrefab, position, owner.transform.rotation);
        }
	}
}
