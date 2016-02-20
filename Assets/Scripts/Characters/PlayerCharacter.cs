using UnityEngine;
using System.Collections;

namespace DiabloKiller {
    public class PlayerCharacter : Character {

        /**
         *  Variables
         */  
        public Camera PlayerCamera;

        // ----------------------- Unity Overriden Methods -------------------------
        // Use this for initialization
        public override void Start() {
            base.Start();

            // create player abilities
            MeleeAbility cleave = new MeleeAbility(this, "Cleave");
            abilityController.AddAbility("Primary", cleave);
            RangedAbility magicMissile = new MagicMissileAbility(this, "Magic Missile");
            abilityController.AddAbility("Secondary", magicMissile);
            AreaAbility avalanche = new AreaAbility(this, "Avalanche");
            abilityController.AddAbility("Ability01", avalanche);
            SelfCastAbility battleShout = new SelfCastAbility(this, "Battle Shout");
            abilityController.AddAbility("Ability02", battleShout);

            // create player stats
            CharacterStat strength = new CharacterStat(CharacterStats.Strength, 12);
            CharacterStat agility = new CharacterStat(CharacterStats.Agility, 15);
            CharacterStat inteligence = new CharacterStat(CharacterStats.Inteligence, 18);
            CharacterStat vitality = new CharacterStat(CharacterStats.Vitality, 10);
            characterSheet.AddStat(CharacterStats.Strength, strength);
            characterSheet.AddStat(CharacterStats.Agility, agility);
            characterSheet.AddStat(CharacterStats.Inteligence, inteligence);
            characterSheet.AddStat(CharacterStats.Vitality, vitality);

            // create player resources
            CharacterResource health = new CharacterResource(CharacterResources.Health, 50,100);
            CharacterResource mana = new CharacterResource(CharacterResources.Mana, 50, 100);
            characterSheet.AddResource(CharacterResources.Health, health);
            characterSheet.AddResource(CharacterResources.Mana, mana);

            HUDInLevel.Instance.Init(characterSheet);
        }


        void Awake() {
        }


        // Update is called once per frame
        public override void Update() {
            base.Update();

            ProcessInput();
            characterMovement.Update();
        } 

        // ----------------------- Public methods -------------------------
        public virtual void OnTriggerEnter(Collider other) {
            characterMovement.OnTriggerEnter(other);
        }

        public override void OnDeath() {
            base.OnDeath();
            MovementAllowed = false;

            // rotate cylinder on death
            Transform t = gameObject.transform;
            t.Rotate(90f, 0f, 0f);
        }

        public void ProcessInput() {
            Ability usedAbility = abilityController.GetAbilityFromInput();

            if (usedAbility == null) {
                return;
            }

            bool abilityReady = abilityController.IsAbilityReady(usedAbility);
            if (!abilityReady) {
                return;
            }

            bool forceStillCast = Input.GetButton("ForceStillCast");
            Ray ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool hitSomething = Physics.Raycast(ray, out hit, 100) && !hit.collider.CompareTag("Player");

            Action newAction = null;
            if (usedAbility.CanCastOnSelf()) {
                newAction = new PlayerActionUseAbility(this, usedAbility, false);
            } else if (hitSomething) {
                if ((hit.collider.CompareTag("Floor") || hit.collider.CompareTag("Wall")) && usedAbility.CanCastOnPoint(forceStillCast)) {
                    usedAbility.SetTarget(hit.point);
                    newAction = new PlayerActionUseAbility(this, usedAbility, forceStillCast);
                } else if (hit.collider.CompareTag("Enemy") && usedAbility.CanCastOnCharacter(hit.collider.gameObject.GetComponent<Character>(), forceStillCast)) {
                    Character target = hit.collider.gameObject.GetComponent<Character>();
                    usedAbility.SetTarget(target);
                    newAction = new PlayerActionUseAbility(this, usedAbility, forceStillCast);
                } else if (!forceStillCast) {
                    newAction = new MoveToPointAction(this, hit.point);
                }
            }

            if (newAction != null) {
                actionController.ExecuteAction(newAction);
            }
        }

    }
}
