using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour {

    public HUDManager hudManager;

    // base stats
    private int strength = 10;
    private int agility = 10;
    private int inteligance = 10;
    private int vitality = 10;

    // secundary stats
    private long maxHealth = 200;
    private int maxMana = 200;

    // current stats
    private long currentHealth = 100;
    private int currentMana = 100;

    public int Strength {
        get { return strength; }
        set { strength = value; }
    }

    public int Agility {
        get { return agility; }
        set { agility = value; }
    }

    public int Inteligence {
        get { return inteligance; }
        set { inteligance = value; }
    }

    public int Vitality {
        get { return vitality; }
        set { vitality = value; }
    }

    public long CurrentHealth {
        get { return currentHealth; }
    }

    public int CurrentMana {
        get { return currentMana; }
        set { currentMana = value; }
    }

    public long MaxHealth {
        get { return maxHealth; }
        set { maxHealth = value; }
    }

    public int MaxMana {
        get { return maxMana; }
        set { maxMana = value; }
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
        if (hudManager != null) {
            hudManager.TakeDamage(currentHealth);
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
        if (hudManager != null) {
            hudManager.PickupHealth(currentHealth);
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
        if (hudManager != null) {
            hudManager.SetMana(currentMana);
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
        if (hudManager != null) {
            hudManager.SetMana(currentMana);
        }
    }

    /**
     *  Private  Methods
     */
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
