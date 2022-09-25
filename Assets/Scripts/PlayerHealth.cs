using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : LivingEntity {

    // Audio
    public AudioClip deathClip;
    public AudioClip hitClip;
    public AudioClip itemPickUpClip;

    private AudioSource playerAudioPlayer;

    private PlayerMovement playerMovement;
    private PlayerShooter playerShooter;
    private PlayerInput playerInput;

    private void Awake() {

        playerMovement = GetComponent<PlayerMovement>();
        playerShooter = GetComponent<PlayerShooter>();
        playerInput = GetComponent<PlayerInput>();

    }

    public override void OnDamage(float damage) {
        base.OnDamage(damage);

        if (healthProperty <= 0 && !dead) {
            Die();
        }
        
    }

    public override void RestoreHealth(float newHealth) {
        base.RestoreHealth(newHealth);

        UIManager.instance.UpdateHealthText((int) healthProperty);

    }

    public override void Die() {
        playerMovement.enabled = false;
        playerShooter.enabled = false;
        playerInput.enabled = false;
        base.Die();
    }

    
}
