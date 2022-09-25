using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    //public BulletData bulletData;

    //private SpriteRenderer spriteRenderer;

    void Start() {

        //// 색깔 설정
        //spriteRenderer = GetComponent<SpriteRenderer>();
        //spriteRenderer.color = bulletData.color;
        //gameObject.SetActive(true);

    }

    void Update() {

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Bullet") {
            // effect 추가 필요
            Destroy(gameObject);
        } else if (collision.collider.tag == "Opponent") {
            //
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {

        IDamageable target = other.GetComponent<IDamageable>();
        if (target != null) {

            // TODO - 하드코딩 된 값이 아닌 IDamageable 을 구현하는 객체의
            // damage 속성으로부터 가져와야 함..
            target.OnDamage(20f);
        }

        IItem item = other.GetComponent<IItem>();

        if (item != null) {
            item.Use(gameObject);
        }
    }
}
