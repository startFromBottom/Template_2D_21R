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

    public override void Die() {

        if (playerMovement != null) {
            playerMovement.enabled = false;
        }

        if (playerShooter != null) {
            playerShooter.enabled = false;
        }

        if (playerInput != null) {
            playerInput.enabled = false;
        }
        
        base.Die();
    }

}
