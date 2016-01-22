using UnityEngine;
using System.Collections;

namespace DiabloKiller {
    public class CharacterResources : MonoBehaviour {

        public long maxHealth =200;
        public long maxMana = 200;

        private long currentHealth;
        private long currentMana;
        private Character owner;

        void Awake() {
        }

        // ----------------------- Public Methods -------------------------
        public void SetOwner(Character owner) {
            this.owner = owner;
        }


        public void ReceiveDamage(long damageToReceive) {
            // if damageToReceive is < 0, error, use recieve health
            if (damageToReceive < 0) {
                return;
            }
            // check if player can take damage
            if (!CanReceiveHealth()) {
                return;
            }

            // decrease health
            Debug.LogFormat("[CharacterStats.ReceiveDamage] Damaging player for: " + damageToReceive);
            currentHealth = currentHealth - damageToReceive;
            if (currentHealth <= 0) {
                currentHealth = 0;
            }
            // Notify HUD
            HUDView hudView = owner.GetHudView();
            if (hudView != null) {
                hudView.TakeDamage(damageToReceive, currentHealth);
            }
        }

        public void ReceiveHealth(long healthToReceive) {
            // if healthToReceive is < 0, error, use recieve health
            if (healthToReceive < 0) {
                return;
            }
            // check if player can recieve health
            if (!CanReceiveHealth()) {
                return;
            }

            // increse health
            Debug.LogFormat("[CharacterStats.ReceiveHealth] Healing player for: " + healthToReceive);
            currentHealth += healthToReceive;
            if (currentHealth > maxHealth) {
                currentHealth = maxHealth;
            }
            // Notify HUD
            HUDView hudView = owner.GetHudView();
            if (hudView != null) {
                hudView.ReceiveHealth(healthToReceive, currentHealth);
            }
        }

        public void ReceiveMana(int manaToReceive) {
            // if manaToReceive < 0, error, use SpendMana
            if (manaToReceive < 0) {
                return;
            }

            Debug.LogFormat("[CharacterStats.ReceiveMana] Get mana: " + manaToReceive);
            currentMana += manaToReceive;

            // if mana is oever maxMana, reduce it to maxMana
            if (currentMana > maxMana) {
                currentMana = maxMana;
            }

            // Notify HUD
            HUDView hudView = owner.GetHudView();
            if (hudView != null) {
                hudView.AddMana(manaToReceive, currentMana);
            }
        }

        public void SpendMana(int manaToSpend) {
            // if manaToLoose < 0, error, use RecieveMana
            if (manaToSpend < 0) {
                return;
            }

            Debug.LogFormat("[CharacterStats.ReceiveMana] Spend mana: " + manaToSpend);
            currentMana -= manaToSpend;

            // if mana < 0, set it to 0
            if (currentMana < 0) {
                currentMana = 0;
            }
            // Notify HUD
            HUDView hudView = owner.GetHudView();
            if (hudView != null) {
                hudView.SpendMana(manaToSpend, currentMana);
            }
        }

        // ----------------------- Private methods -------------------------
        private bool CanReceiveHealth() {
            // check if dead
            bool result = currentHealth != 0;


            return result;
        }

        private bool CanReceiveDamage() {
            bool result = true;

            // TODO: check if player can recieve damage (i.e if invurbelable or similar)

            return result;
        }

    }
}
