using UnityEngine;
using System.Collections;

public class PlayerShooter : MonoBehaviour {

    public Gun gun;

    private PlayerInput playerInput;

    // Use this for initialization
    void Start() {
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable() {
        gun.gameObject.SetActive(true);
    }

    private void OnDisable() {
        gun.gameObject.SetActive(false);
    }

    private void Update() {

        if (playerInput.fire) {
            gun.Fire();
        }
    }

}
