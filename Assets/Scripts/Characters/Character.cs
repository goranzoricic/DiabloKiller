using UnityEngine;
using System.Collections;

namespace DiabloKiller {
    public abstract class Character : MonoBehaviour {

        public NavMeshAgent navMeshAgent;
        [HideInInspector]
        public CharacterMovement characterMovement;

        public bool MovementAllowed {
            get { return characterMovement.MovementAllowed; }
            set { characterMovement.MovementAllowed = value; }
        }

        protected ActionController actionController;
        protected AbilityController abilityController;
        protected BuffController buffController;

        protected CharacterSheet characterSheet;

        // Use this for initialization
        public virtual void Start() {
            Debug.LogFormat("[Character.Start] {0}", gameObject.name);
            actionController = new ActionController(this);
            abilityController = new AbilityController(this);
            buffController = new BuffController(this);

            // creaate empty character sheet, to be populated by derived classes
            characterSheet = new CharacterSheet();

            characterMovement = new CharacterMovement();
            characterMovement.SetOwner(this);
            characterMovement.Init();
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

        public virtual void StartAction(Action action) {
            // TODO fix this
            //actionController.StartAction(action);
        }

        public CharacterSheet CharacterSheet() {
            return characterSheet;
        }
    }
}
