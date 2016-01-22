using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DiabloKiller {
    public class GlobalUpdater : MonoBehaviour {
        List<Updateable> Updateables = new List<Updateable>();

        // Use this for initialization
        void Start() {
        }

        // Update is called once per frame
        void Update() {
            foreach (Updateable updateable in Updateables) {
                updateable.Update();
            }
        }

        public void RegisterForUpdates(Updateable updateable) {
            Debug.Assert(!Updateables.Contains(updateable), "Trying to register an updateable that is already registered for updates.");
            Updateables.Add(updateable);
        }

        public void UnegisterForUpdates(Updateable updateable) {
            Updateables.Remove(updateable);
        }
    }
}
