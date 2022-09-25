using UnityEngine;

public class HealthPack : MonoBehaviour, IItem {

    public float health = 20;

    public void Use(GameObject target) {

        if (target.tag == "Bullet") {
            GameObject playerObj = 
                GameObject.FindGameObjectWithTag("Player");
            PlayerHealth playerHealth =
                playerObj.GetComponent<PlayerHealth>();
            playerHealth.healthProperty += health;

        }

        Destroy(gameObject);
    } 

}
