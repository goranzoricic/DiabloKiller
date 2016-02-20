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

        public CharacterSheet characterSheet {
            get;
            private set;
        }

        protected long GetHealth() {
            return characterSheet.GetResource(CharacterResources.Health).CurrentAmmount;
        }
        protected long GetMana() {
            return characterSheet.GetResource(CharacterResources.Mana).CurrentAmmount;
        }

        public void ReceiveDamage(long damageToReceive) {
            // if damageToReceive is < 0, error, use recieve health
            if (damageToReceive < 0) {
                Debug.LogErrorFormat("[Character.ReceiveHealth] Trying to apply a negative ammount of damage: {0}", damageToReceive);
                return;
            }
            // check if player can take damage
            if (!characterSheet.CanReceiveDamage()) {
                return;
            }
            characterSheet.SpendResource(CharacterResources.Health, damageToReceive);
            long health = GetHealth();
            Debug.LogFormat("Health zero, dying now   -  {0}", health);

            if (GetHealth() <= 0) {
                OnDeath();
            }
        }

        public void ReceiveHealth(long healthToReceive) {
            // if healthToReceive is < 0, error, use recieve damage
            if (healthToReceive < 0) {
                Debug.LogErrorFormat("[Character.ReceiveHealth] Trying to apply a negative ammount of healing: {0}", healthToReceive);
                return;
            }
            // check if player can recieve health
            if (!characterSheet.CanReceiveHealth()) {
                return;
            }
            characterSheet.ReceiveResource(CharacterResources.Health, healthToReceive);
        }
    }
}
