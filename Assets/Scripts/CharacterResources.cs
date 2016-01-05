using UnityEngine;
using System.Collections;

public class CharacterResources : MonoBehaviour {

	public long health = 100;
	public long maxHealth = 200;
	public long mana = 100;
	public long maxMana = 200;

	public void ReceiveHealth(long healthToReceive) 
	{
		// if healthToReceive is < 0, error, use recieve damage
		if (healthToReceive < 0) {
			return;
		}
		// if character is already dead, don't change health
		if (health <= 0) {
			return;
		}
		// increase health
		health = health + healthToReceive;

		// if health is above max, set it to max
		if (health > maxHealth) {
			health = maxHealth;
		}
	}

	public void ReceiveDamage(long damageToReceive) 
	{
		// if damageToReceive is < 0, error, use recieve health
		if (damageToReceive < 0) {
			return;
		}
		// if character is already dead, don't change health
		if (health <= 0) {
			return;
		}

		// decrease health
		health = health - damageToReceive;
        // if health <= 0, character is dead
        if (health <= 0) {
            Die();
        }
	}

	public void Die()
	{
        Debug.LogError("Die!");
		// if character is dead, set health to 0
		health = 0;
	}

	public void ReceiveMana(long manaToReceive)	
	{
		// if manaToReceive < 0, error, use SpendMana
		if (manaToReceive < 0) {
			return;
		}

		mana = mana + manaToReceive;

		// if mana is oever maxMana, reduce it to maxMana
		if (mana > maxMana) {
			mana = maxMana;
		}
	}

	public void SpendMana(long manaToSpend)
	{
		// if manaToLoose < 0, error, use RecieveMana
		if (manaToSpend < 0) {
			return;
		}

		mana = mana - manaToSpend;

		// if mana < 0, set it to 0
		if (mana < 0) {
			mana = 0;
		}

	}


}
