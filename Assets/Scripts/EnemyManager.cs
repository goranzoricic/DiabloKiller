using UnityEngine;
using System.Collections;

namespace DiabloKiller {
    public class EnemyManager : Updateable {
        public static EnemyManager Instance {
            get { return Singleton<EnemyManager>.Instance; }
            private set { }
        }

        // Update is called once per frame
        public override void Update() {
            //Debug.Log("[EnemyManager.Update] update executed");

        }

        public void AddEnemy(EnemyCharacter enemy) {
            Debug.LogFormat("[EnemyManager.Update] Enemy added to the manager: {0}", enemy.gameObject.name);
        }
    }
}
    
