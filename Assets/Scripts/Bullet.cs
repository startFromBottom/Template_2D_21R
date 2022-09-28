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
            GameManager.instance.SubtractScore(collideWithBulletScore);
            // effect 추가 필요
            Destroy(gameObject);
        } 
        
        /**
         * TODO : tag가 Player일 때는 OnTriggerEnter로,
         * tag가 Opponent일 때는 OnCollisionEnter로 bullet object를 파괴하고 있음.
         * 일관된 로직으로 처리할 수는 없을까
         */
        else if (collision.collider.CompareTag("Opponent")) {
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
        
        if (other.CompareTag("Player")) {
            Destroy(gameObject);
        }
    }
}
