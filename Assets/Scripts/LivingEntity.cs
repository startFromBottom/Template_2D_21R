using UnityEngine;
using System;


public class LivingEntity : MonoBehaviour, IDamageable {

    public float startingHealth = 100f;
    public float health { get; protected set; }
    public bool dead { get; protected set; }
    public event Action onDeath; // 사망시 발동 이벤트

    protected virtual void OnEnable() {
        dead = false;
        health = startingHealth;
    }

    public virtual void OnDamage(float damage) {

        health -= damage;
        print("bcde");

        if (health <= 0 && !dead) {
            Die();
        }

    }

    public virtual void RestoreHealth(float newHealth) {
        if (dead) {
            // 이미 사망한 경우에는 체력 회복이 불가능
            return;
        }

        health += newHealth;
    }

    public virtual void Die() {
        if (onDeath != null) {
            onDeath();
        }

        dead = true;
    }
}
