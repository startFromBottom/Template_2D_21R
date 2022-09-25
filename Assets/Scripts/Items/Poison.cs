using UnityEngine;


public class Poison: MonoBehaviour, IItem {

    public float damage = -10;

    public void Use(GameObject target) {

        if (target.tag == "Bullet") {

            // 플레이어의 체력은 감소
            // 반대로 상대방 총알이 맞추면
            // 상대방의 체력이 감소
        }

        Destroy(gameObject);
    }

}
