using UnityEngine;


public class Coin : MonoBehaviour, IItem {

    public int score = 50;

    public void Use(GameObject target) {

        if (target.tag == "Bullet") {
            ScoreManager.instance.AddScore(score);
        }
        Destroy(gameObject);
    }
    
}
