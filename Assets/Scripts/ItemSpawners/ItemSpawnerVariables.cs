using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/ItemSpawnwerVariables",
    fileName = "Item Spawner")]
public class ItemSpawnerVariables : ScriptableObject {
    
    // 아이템 생성 간격
    public float timeBetSpawnMax = 0.3f;
    public float timeBetSpawnMin = 0.1f;
    
    public float destroyTime = 3f;
    
    // 아이템 생성 위치
    public float yMin = -3.5f;
    public float yMax = 3.5f;
    public float xMin = -2f;
    public float xMax = 2f;
    
}