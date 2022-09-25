using UnityEngine;

public class HealthPack : MonoBehaviour, IItem {

    public float health = 20;

    public void Use(GameObject target) {

        if (target.tag == "Bullet") {

            // 플레이어의 체력 증가
            // 반대로 상대방 총알이 맞추면
            // 상대방의 체력은 증가
        }

        Destroy(gameObject);
    } 

}
