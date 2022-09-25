using UnityEngine;

public class AmmoPack : MonoBehaviour, IItem {

    public int ammo = 10;

    public void Use(GameObject target) {

        if (target.tag == "Bullet") {
            // Gun의 탄알 수 증가
        }
        Destroy(gameObject);
    }
}
