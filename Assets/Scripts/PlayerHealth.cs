using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : LivingEntity {

    // Audio
    public AudioClip deathClip;
    public AudioClip hitClip;
    public AudioClip itemPickUpClip;

    private AudioSource playerAudioPlayer;


    // gun의 animator도 여기에 추가?


    private void Awake() {
        
    }

    protected override void OnEnable() {

        base.OnEnable();
        UIManager.instance.UpdateHealthText((int) startingHealth);

    }

    public override void OnDamage(float damage) {
        base.OnDamage(damage);
        print("update health text");
        UIManager.instance.UpdateHealthText((int) health);
    }

    public override void RestoreHealth(float newHealth) {
        base.RestoreHealth(newHealth);

        UIManager.instance.UpdateHealthText((int) health);

    }

    public override void Die() {
        base.Die();

    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    
}
