using UnityEngine;
using System.Collections;

namespace DiabloKiller {
	public class MagicMissileAbility : RangedAbility {
		static private Object projectilePrefab;

        public MagicMissileAbility(Character owningCharacter, string name) : base(owningCharacter, name) {
        	if (projectilePrefab == null) {
        		projectilePrefab = Resources.Load("Prefabs/MagicMissile");
        	}
        }

        public override bool CanCastOnPoint(bool forceStillCast) {
            return true;
        }

        // Use this for initialization
        public override void Start() {
            Debug.Log("[MagicMissileAbility.Start]");

            Vector3 direction = (targetPoint - owner.transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            owner.transform.rotation = rotation;
            Vector3 position = owner.transform.position + direction + new Vector3(0.0f,1.5f,0.0f);
			GameObject missile = (GameObject)GameObject.Instantiate(projectilePrefab, position, rotation);
			missile.GetComponent<Rigidbody>().velocity = 7.5f*direction;

            owner.characterMovement.Stop(false, false);
        }

        // Update is called once per frame
        public override void Update() {

        }
  	}
}
