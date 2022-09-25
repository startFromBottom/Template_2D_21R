using UnityEngine;

public class AmmoPack : MonoBehaviour, IItem {

    public int ammo = 10;

    public void Use(GameObject target) {
        
        if (target.CompareTag("Bullet")) {
            GameObject playerObj = 
                GameObject.FindGameObjectWithTag("Player");
            Gun gun = playerObj.GetComponentInChildren<Gun>();
            gun.ammoRemainProperty += ammo;
        }
        Destroy(gameObject);
    }
}
