using UnityEngine;


public class Poison: MonoBehaviour, IItem {

    public float damage = 10;

    public void Use(GameObject target) {

        if (target.tag == "Bullet") {
            GameObject playerObj =
                GameObject.FindGameObjectWithTag("Player");
            PlayerHealth playerHealth =
                playerObj.GetComponent<PlayerHealth>();
            playerHealth.healthProperty -= damage;
        }

        Destroy(gameObject);
    }

}
