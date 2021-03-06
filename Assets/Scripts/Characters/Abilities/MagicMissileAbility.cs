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

        // Use this for initialization
        public override void Start(bool forceStillCast) {
            Debug.Log("[MagicMissileAbility.Start]");

            Vector3 direction = targetPoint - owner.transform.position;
            direction.y = 0;
            direction.Normalize();
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
