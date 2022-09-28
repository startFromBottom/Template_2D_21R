using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    private int collideWithBulletScore = 2;

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
            ScoreManager.instance.SubtractScore(collideWithBulletScore);
            // effect 추가 필요
            Destroy(gameObject);
        }
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
        }

        IItem item = other.GetComponent<IItem>();
        if (item != null) {
            item.Use(gameObject);
        }

        Destroy(gameObject);
    }
}
