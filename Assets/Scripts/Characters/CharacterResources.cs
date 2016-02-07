using UnityEngine;
using System.Collections;

namespace DiabloKiller {
    public class CharacterResources : MonoBehaviour {

        public long maxHealth = 200;
        public long maxMana = 200;

        public long currentHealth  { get; set; }
        public long currentMana    { get; set; }

        private Character owner;

        // ----------------------- Public Methods -------------------------
        public void Awake() {
        }

        public void Init() {
            currentHealth = maxHealth / 2;
            currentMana = maxMana / 2;
        }

        public void SetOwner(Character owner) {
            this.owner = owner;
        }


        public void ReceiveDamage(long damageToReceive) {
            // if damageToReceive is < 0, error, use recieve health
            if (damageToReceive < 0) {
                return;
            }
            // check if player can take damage
            if (!CanReceiveDamage()) {
                return;
            }

            // decrease health
            currentHealth = currentHealth - damageToReceive;
            if (currentHealth <= 0) {
                currentHealth = 0;
            }
            Debug.LogFormat("[CharacterResources.ReceiveDamage] Damaging {0} for {1}, currentHealth {2}", owner, damageToReceive, currentHealth);
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
            currentHealth += healthToReceive;
            if (currentHealth > maxHealth) {
                currentHealth = maxHealth;
            }
            Debug.LogFormat("[CharacterResources.ReceiveHealth] Healing character for {0}, currentHealth {1}", healthToReceive, currentHealth);
        }

        public void ReceiveMana(int manaToReceive) {
            // if manaToReceive < 0, error, use SpendMana
            if (manaToReceive < 0) {
                return;
            }

            Debug.LogFormat("[CharacterResources.ReceiveMana] Get mana: " + manaToReceive);
            currentMana += manaToReceive;

            // if mana is oever maxMana, reduce it to maxMana
            if (currentMana > maxMana) {
                currentMana = maxMana;
            }
        }

        public void SpendMana(int manaToSpend) {
            // if manaToLoose < 0, error, use RecieveMana
            if (manaToSpend < 0) {
                return;
            }

            Debug.LogFormat("[CharacterResources.SpendMana] Spend mana: " + manaToSpend);
            currentMana -= manaToSpend;

            // if mana < 0, set it to 0
            if (currentMana < 0) {
                currentMana = 0;
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
