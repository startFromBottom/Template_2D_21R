using UnityEngine;
using System;


public class LivingEntity : MonoBehaviour, IDamageable {

    public float startingHealth = 100f;
    private float health;

    public float healthProperty {
        get {
            return health;
        }
        set {
            health = value;
            if (health < 0) {
                health = 0;
            }
            UIManager.instance.UpdateHealthText((int) healthProperty);
        }
    }

    public bool dead { get; protected set; }
    public event Action onDeath; // 사망시 발동 이벤트

    protected virtual void OnEnable() {
        dead = false;
        health = startingHealth;
    }

    public virtual void OnDamage(float damage) {

        if (dead) {
            return;
        }
        
        healthProperty -= damage;
        if (healthProperty <= 0 && !dead) {
            Die();
        }

    }

    public virtual void RestoreHealth(float newHealth) {
        if (dead) {
            return;
        }

        health += newHealth;
    }

    public virtual void Die() {
        if (onDeath != null) {
            onDeath();
            print("onDeath start");
        }

        dead = true;
    }
}
