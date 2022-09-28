using UnityEngine;


/**
 * Not used
 */
public class HealthPack : MonoBehaviour, IItem {

    public float health = 20;

    public void Use(GameObject target) {

        if (target.tag == "Bullet") {
            GameObject playerObj = 
                GameObject.FindGameObjectWithTag("Player");
            
            LivingEntity playerHealth =
                playerObj.GetComponent<LivingEntity>();
            playerHealth.RestoreHealth(health);

        }

        Destroy(gameObject);
    } 

}
