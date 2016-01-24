using UnityEngine;
using System.Collections;

namespace DiabloKiller {
    public abstract class Character : MonoBehaviour {

        [HideInInspector]
        public NavMeshAgent navMeshAgent;

        public bool movementAllowed = true;
        public Component hudView;

        protected ActionController actionController;
        protected AbilityController abilityController;
        protected BuffController buffController;

        protected CharacterResources characterResources;

        // Use this for initialization
        public virtual void Start() {
            Debug.LogFormat("[Character.Start] {0}", gameObject.name);
            actionController = new ActionController(this);
            abilityController = new AbilityController(this);
            buffController = new BuffController(this);

            characterResources = gameObject.GetComponent<CharacterResources>();
            characterResources.SetOwner(this);
            characterResources.Init();
        }

        public virtual void Update() {
            abilityController.Update();
            actionController.Update();
            buffController.Update();
        }

        public virtual void OnDeath() {
            abilityController.OnDeath();
            // TODO fix this
            //actionController.OnDeath();
        }

        public virtual Ability GetUsedAbility() {
            return null;
        }

        public virtual void StartAction(Action action) {
            // TODO fix this
            //actionController.StartAction(action);
        }

        public HUDView GetHudView() {
            HUDView result = null;
            try {
                result = (HUDView)hudView.GetComponent<HUDView>();
            } catch (UnassignedReferenceException e) {
                // do nothing
            }
            return result;
        }

        protected float PathLength(NavMeshPath path) {
            if (path.corners.Length < 2)
                return 0;

            Vector3 previousCorner = path.corners[0];
            float lengthSoFar = 0.0F;
            int i = 1;
            while (i < path.corners.Length) {
                Vector3 currentCorner = path.corners[i];
                lengthSoFar += Vector3.Distance(previousCorner, currentCorner);
                previousCorner = currentCorner;
                i++;
            }
            return lengthSoFar;
        }
    }
}
