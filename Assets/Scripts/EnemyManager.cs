using UnityEngine;
using System.Collections;

public class EnemyManager : Updateable {
    private static EnemyManager instance;

    public static EnemyManager Instance() {
        return Singleton<EnemyManager>.Instance;
    }

	// Update is called once per frame
	public override void Update () {
        //Debug.Log("[EnemyManager.Update] update executed");
	
	}

    public void AddEnemy(EnemyCharacter enemy) {
        Debug.LogFormat("[EnemyManager.Update] Enemy added to the manager: {0}", enemy.gameObject.name);
    }
}
    
