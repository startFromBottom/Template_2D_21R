using UnityEngine;
using System.Collections;

public class RandomItemSpawner : BaseItemSpawner {

    public GameObject[] items;

    public override void Spawn() {

        if (GameManager.instance.isGameOver) {
            return;
        }

        Vector2 spawnPosition = GetRandomPoint();
        GameObject selectedItem = items[Random.Range(0, items.Length)];
        GameObject item = Instantiate(selectedItem, spawnPosition,
            Quaternion.identity);
        item.SetActive(true);

        Destroy(item, vars.destroyTime);
    }
    
    private Vector2 GetRandomPoint() {

        float xPos = Random.Range(vars.xMin, vars.xMax);
        float yPos = Random.Range(vars.yMin, vars.yMax);

        return new Vector2(xPos, yPos);
     
    }

}
