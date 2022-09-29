
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour {
    public string moveAxisName = "Vertical";
    public string fireButtonName = "Fire1";
    

    public bool moveLeft { get; private set; }
    public bool moveRight { get; private set; }
    public bool standby { get; private set; }
    public bool fire { get; private set; }
    public bool pulling { get; private set;}
    public Vector2 mousePos { get; private set; }
    void Update() {
        if (GameManager.instance != null && GameManager.instance.isGameOver) {
            moveLeft = false;
            moveRight = false;
            standby = false;
            pulling = false;
            fire = false;
        }
        // inactivate left, right movement
        // moveLeft = Input.GetKey(KeyCode.LeftArrow);
        // moveRight = Input.GetKey(KeyCode.RightArrow);
        standby = Input.GetMouseButtonDown(0);
        pulling = Input.GetMouseButton(0);
        fire = Input.GetMouseButtonUp(0);
        
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
