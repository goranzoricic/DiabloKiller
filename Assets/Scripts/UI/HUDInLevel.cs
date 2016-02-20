using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace DiabloKiller {
    public class HUDInLevel : MonoBehaviour {
        private static object threadLock = new object();
        private static HUDInLevel instance;

        public static HUDInLevel Instance {
            get {
                return InstanceCreation();
            }
        }
        public static HUDInLevel InstanceCreation() {
            if (instance == null) {
                lock (threadLock) {
                    Object hudPrefab = Resources.Load("Prefabs/HUD/HUDInLevel");
                    GameObject hudInstance = (GameObject)Object.Instantiate(hudPrefab);
                    instance = hudInstance.GetComponent<HUDInLevel>();
                }
            }
            return instance;
        }

        public Slider healthSlider;                                 // Reference to the UI's health bar.
        public Slider manaSlider;                                   // Reference to the UI's mana bar.
        public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
        public AudioClip deathClip;                                 // The audio clip to play when the player dies.
        public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
        public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.

        CharacterSheet characterSheet;                              // Reference to player character sheet

        // Use this for initialization
        void Start() {

        }

        void Awake() {
        }

        void Update() {
            CharacterResource health = characterSheet.GetResource(CharacterResources.Health);
            CharacterResource mana = characterSheet.GetResource(CharacterResources.Mana);

            healthSlider.maxValue = health.MaxAmmount;
            manaSlider.maxValue = mana.MaxAmmount;
            healthSlider.value = health.CurrentAmmount;
            manaSlider.value =  mana.CurrentAmmount;
        }

        public void Init(CharacterSheet characterSheet) {
            this.characterSheet = characterSheet;
            CharacterResource health = characterSheet.GetResource(CharacterResources.Health);
            CharacterResource mana = characterSheet.GetResource(CharacterResources.Mana);
            Debug.LogFormat("[HUDInLevel.Init] Initalizing HUD, maxHealh: {0}, maxMana: {1}, health: {2}, mana: {3} ", health.MaxAmmount, mana.MaxAmmount, health.CurrentAmmount, mana.CurrentAmmount);
            healthSlider.maxValue = health.MaxAmmount;
            manaSlider.maxValue = mana.MaxAmmount;
            healthSlider.value = health.CurrentAmmount;
            manaSlider.value = mana.CurrentAmmount;
        }

        public void Death() {
        }
    }
}
