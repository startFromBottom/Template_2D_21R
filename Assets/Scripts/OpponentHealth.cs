

using System;

public class OpponentHealth : LivingEntity {

    private PlayerInput playerInput;
    // private PlayerShooter playerShooter;

    private void Awake() {
        playerInput = GetComponent<PlayerInput>();
    }

    public override void OnDamage(float damage) {
        base.OnDamage(damage);
        if (healthProperty <= 0 && !dead) {
            Die();
        }
        Resurrection();
    }
    private void Resurrection() {
        dead = false;
        healthProperty = startingHealth;
        playerInput.enabled = true;
    }

    public override void Die() {
        if (playerInput != null) {
            playerInput.enabled = false;
        }
        
        base.Die();
    }
}