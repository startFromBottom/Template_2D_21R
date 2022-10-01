using System;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 3f;
    public Transform player;
    Vector2 direction;

    private Camera cam;

    private PlayerInput playerInput;
    
    private Vector3 startPoint;
    private Vector3 endPoint;

    // Use this for initialization
    void Start() {
        playerInput = GetComponent<PlayerInput>();
        cam = Camera.main;
    }

    private void Update() {
        Rotate();
        Move();
    }

    private void Rotate() {
        if (playerInput.pulling) {
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            direction = -player.position + currentPoint;
            player.transform.right = direction;
        }
    }

    private void Move() {
        if (playerInput.moveLeft) {
            player.transform.position +=
                new Vector3(-1 * Time.deltaTime * moveSpeed, 0, 0);
        } else if (playerInput.moveRight) {
            player.transform.position
                += new Vector3(Time.deltaTime * moveSpeed, 0, 0);
        }
    }
}
