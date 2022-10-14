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
    private TrajectoryLine tl;

    // Use this for initialization
    void Start() {
        playerInput = GetComponent<PlayerInput>();
        cam = Camera.main;
        tl = GetComponent<TrajectoryLine>();
    }

    private void Update() {
        if (playerInput.standby) {
            startPoint = playerInput.mousePos;
            startPoint.z = 15;
        }
        if (playerInput.pulling) {
            Vector3 currentPoint = playerInput.mousePos;
            currentPoint.z = 15;
            tl.RenderLine(startPoint, currentPoint);
            Rotate();
        }
        if (playerInput.fire) {
            endPoint = playerInput.mousePos;
            endPoint.z = 15;
            
            tl.EndLine();
            
            // force = new Vector2(
            //     Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x),
            //     Math.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y)
            // );
            
        }

    }

    private void Rotate() {
        Vector3 currentPoint = playerInput.mousePos;
        direction = player.position - currentPoint;
        player.transform.right = direction;
    }
}
