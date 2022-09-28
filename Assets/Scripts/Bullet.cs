using System;
using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    private int collideWithBulletScore = 2;
    private Animator bulletAnimator;

    private void Awake() {
        bulletAnimator = GetComponent<Animator>();

    }

    void Start() {
        //// 색깔 설정
        //spriteRenderer = GetComponent<SpriteRenderer>();
        //spriteRenderer.color = bulletData.color;
        //gameObject.SetActive(true);

    }

    void Update() {

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (GameManager.instance.isGameOver) {
            return;
        }
        
        if (collision.collider.CompareTag("Bullet")) {
            print("collide with bullet");
            ScoreManager.instance.SubtractScore(collideWithBulletScore);

            StartCoroutine(ShotEffect());
            // effect 추가 필요
            // Destroy(gameObject);
        }
    }

    private IEnumerator ShotEffect() {
        bulletAnimator.SetTrigger("Collide");
        yield return new WaitForSeconds(0.15f);
        Destroy(gameObject);
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if (GameManager.instance.isGameOver) {
            return;
        }

        IDamageable target = other.GetComponent<IDamageable>();
        if (target != null) {
            // TODO - 하드코딩 된 값이 아닌 IDamageable 을 구현하는 객체의
            // damage 속성으로부터 가져와야 함..
            target.OnDamage(100f);
            Destroy(gameObject);
        }

        IItem item = other.GetComponent<IItem>();
        if (item != null) {
            item.Use(gameObject);
        }
    }
}
