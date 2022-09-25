using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour {

    public GameObject[] items;

    // 아이템 생성 시간 간격
    public float timeBetSpawnMax = 0.05f;
    public float timeBetSpawnMin = 0.03f;
    private float timeBetSpawn;

    private float destroyTime = 7f;

    // TODO: 하드코딩된 값이 아니라 화면 비율에 맞춰 동적으로 변화되게
    // 할 수 있니
    private float yMin = -3.5f;
    private float yMax = 3.5f;

    private float xMin = -2f;
    private float xMax = 2f;

    private float lastSpawnTime;

    private void Start() {
        timeBetSpawn =
            Random.Range(timeBetSpawnMin, timeBetSpawnMax);
        lastSpawnTime = 0;
    }

    private void Update() {

       if (Time.time >= lastSpawnTime + timeBetSpawn) {
            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(timeBetSpawnMin,
                timeBetSpawnMax);
            Spawn();
        }
    }

    private void Spawn() {

        Vector2 spawnPosition = GetRandomPoint();

        GameObject selectedItems = items[Random.Range(0, items.Length)];

        GameObject item = Instantiate(selectedItems, spawnPosition,
            Quaternion.identity);
        item.SetActive(true);

        Destroy(item, destroyTime);
    }

    private Vector2 GetRandomPoint() {

        float xPos = Random.Range(xMin, xMax);
        float yPos = Random.Range(yMin, yMax);

        return new Vector2(xPos, yPos);
     
    }

}
