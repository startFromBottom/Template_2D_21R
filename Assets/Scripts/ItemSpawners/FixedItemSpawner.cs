
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class FixedItemSpawner : MonoBehaviour, IItemSpawner {

    public ItemSpawnerVariables vars;
    private GameObject[] items;
    private Vector2[] points;
    
    private void Start() {
    }

    private void Update() {
        
        
    }
    
    public void Spawn() {

        if (GameManager.instance.isGameOver) {
            return;
        }
        
        
    }


}