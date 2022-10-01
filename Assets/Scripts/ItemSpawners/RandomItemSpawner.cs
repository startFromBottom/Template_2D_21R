using UnityEngine;
using System.Collections;

public class RandomItemSpawner : MonoBehaviour, IItemSpawner {

    public GameObject[] items;
    public ItemSpawnerVariables vars;
    
    private float timeBetSpawn;
    private float lastSpawnTime;

    private void Start() {
        timeBetSpawn =
            Random.Range(vars.timeBetSpawnMin, vars.timeBetSpawnMax);
        lastSpawnTime = 0;
    }

    private void Update() {

       if (Time.time >= lastSpawnTime + timeBetSpawn) {
            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(vars.timeBetSpawnMin,
                vars.timeBetSpawnMax);
            Spawn();
        }
    }

    public void Spawn() {

        if (GameManager.instance.isGameOver) {
            return;
        }

        Vector2 spawnPosition = GetRandomPoint();
        GameObject selectedItems = items[Random.Range(0, items.Length)];
        GameObject item = Instantiate(selectedItems, spawnPosition,
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
