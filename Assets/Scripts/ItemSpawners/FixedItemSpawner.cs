
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;


/**
 * Need to be fixed. Not completed.
 */
public class FixedItemSpawner : BaseItemSpawner {
    
    private Dictionary<Vector2, GameObject> pointItemDic;
    
    private int currentIndex = 0;

    private void Start() {
        base.Start();
        SetItemPointDic();
    }
    
    private void OnEnable() {
        SetItemPointDic();
    }

    public override void Spawn() {

        var points = pointItemDic.Keys;
        print("currentIndex ==== " + currentIndex);

        if (GameManager.instance.isGameOver
            || currentIndex >= points.Count) {
            return;
        }

        var spawnPosition = points.ElementAt(currentIndex);
        var selectedItem = pointItemDic.GetValueOrDefault(spawnPosition);

        print("selectedItem ==== " + selectedItem);
        // GameObject item = Instantiate(selectedItem, spawnPosition,
        //     Quaternion.identity);
        // item.SetActive(true);
        // Destroy(item, vars.destroyTime);

        currentIndex++;
    }

    /**
     *  TODO: 스테이지별 아이템 스폰 위치를 담은 파일을 가져와, pointItemDoc 정보를 가져오도록 수정.
     */
    private void SetItemPointDic() {
        
        pointItemDic = new Dictionary<Vector2, GameObject>();
        pointItemDic.Add(new Vector2(-1, 1), GameObject.Find("AmmoPack"));
        pointItemDic.Add(new Vector2(0, 0), GameObject.Find("Coin"));
        pointItemDic.Add(new Vector2(0.5f, 0.5f), GameObject.Find("Coin"));
        pointItemDic.Add(new Vector2(0.7f, 0.7f), GameObject.Find("Coin"));

        currentIndex = 0;
    }
}