using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDManager : MonoBehaviour {
    public Slider healthSlider;                                 // Reference to the UI's health bar.
    public Slider manaSlider;                                   // Reference to the UI's mana bar.
    public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
    public AudioClip deathClip;                                 // The audio clip to play when the player dies.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.

    Animator anim;                                              // Reference to the Animator component.
    AudioSource playerAudio;                                    // Reference to the AudioSource component.
    CharacterResources playerResources;                         // Reference to player resources script
    bool damaged = false;                                       // True when the player gets damaged.

    // Use this for initialization
    void Start() {

    }

    void Awake() {
        // Setting up the references.
        anim = GetComponent<Animator>();
        //playerAudio = GetComponent<AudioSource>();
        playerResources = GetComponentInChildren<CharacterResources>();
    }


    void Update() {
        // If the player has just been damaged...
        if (damaged) {
            // ... set the colour of the damageImage to the flash colour.
            damageImage.color = flashColour;
        }
        // Otherwise...
        else {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag.
        damaged = false;
    }

    public void Init(long maxHelath, int maxMana) {
        healthSlider.maxValue = maxHelath;
        manaSlider.maxValue = maxMana;
    }


    public void Death()
    {
        // Turn off any remaining shooting effects.
        //playerShooting.DisableEffects();

        // Tell the animator that the player is dead.
        //anim.SetTrigger("Die");

        // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
        //playerAudio.clip = deathClip;
        //playerAudio.Play();

        // Turn off the movement and shooting scripts.
        playerResources.enabled = false;
    }

    public void TakeDamage(long currentHealth) {
        // Set the damaged flag so the screen will flash.
        //damaged = true;

        // Set the health bar's value to the current health.
        healthSlider.value = currentHealth;

        // Play the hurt sound effect.
        //playerAudio.Play();
    }

    public void PickupHealth(long currentHealth)
    {
        // Set the health bar's value to the current health.
        healthSlider.value = currentHealth;

    }

    public void SetMana(long currentMana)
    {
        // Set the health bar's value to the current health.
        manaSlider.value = currentMana;

    }

}
