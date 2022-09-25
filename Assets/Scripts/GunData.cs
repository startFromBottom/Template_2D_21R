using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Scriptable/GunData", fileName ="Gun Data")]
public class GunData : ScriptableObject {


    public AudioClip shotClip; // 발사 소리
    public AudioClip reloadClip; // 재장전 소리


    public float damage = 25;

    public int startAmmoRemain = 100;
    //public int magCapacity = 25; // 

    public float timeBetFire = 0.12f; // 탄알 발사 간격 
}
