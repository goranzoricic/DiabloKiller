using UnityEngine;
using System.Collections;

namespace DiabloKiller {
    public abstract class Updateable {
        public Updateable() {
        }

        ~Updateable() {

        }
        public void RegisterForUpdates() {
            GameObject updaterObject = GameObject.Find("GlobalUpdater");
            if (!updaterObject) {
                Object updaterPrefab = Resources.Load("Prefabs/GlobalUpdater");
                updaterObject = (GameObject)Object.Instantiate(updaterPrefab);
            }
            GlobalUpdater updater = updaterObject.GetComponent<GlobalUpdater>();
            updater.RegisterForUpdates(this);
        }

        public abstract void Update();
    }
}
