using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    public enum State {
        Ready,  // 발사 준비
        Empty,  // 탄알집이 빈 상태
        Reloading // 재장전 중
    }

    public State state { get; private set; }

    public Transform fireTransform;

    public GameObject bullet;

    private AudioSource gunAudioPlayer; // 총 소리 재생기

    public GunData gunData; // 총의 현재 데이터

    private int ammoRemain = 100;
    public int ammoRemainProperty {
        get {
            return ammoRemain;
        }
        set {
            ammoRemain = value;
            UIManager.instance.UpdateAmmoText(ammoRemain);
        }
    }

    private float lastFireTime; // 총을 마지막으로 발사한 시점

    public Animator gunAnimator;

    private void Awake() {
        gunAudioPlayer = GetComponent<AudioSource>();
        gunAnimator = GetComponent<Animator>();
    }

    private void OnEnable() {
        ammoRemain = gunData.startAmmoRemain;

        state = State.Ready;
        lastFireTime = 0;
    }

    public void Fire() {

        if (state == State.Ready
               && Time.time >= lastFireTime + gunData.timeBetFire) {
            lastFireTime = Time.time;
            gunAnimator.SetTrigger("Shoot");
            Shot();
        }

    }

    private void Shot() {

        GameObject BulletInstance = 
            Instantiate(bullet, fireTransform.position, fireTransform.rotation);
        BulletInstance.SetActive(true);
        BulletInstance.GetComponent<Rigidbody2D>()
            .AddForce(BulletInstance.transform.right * 600);

        gunAnimator.SetTrigger("Shoot");
        Destroy(BulletInstance, 2);

        ammoRemainProperty--;
        if (ammoRemainProperty <= 0) {
            state = State.Empty;
        }
    }

}
