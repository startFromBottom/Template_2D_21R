using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

    public string moveAxisName = "Vertical";
    public string fireButtonName = "Fire1";

    public bool moveLeft { get; private set; }
    public bool moveRight { get; private set; }
    public bool fire { get; private set; }

    public Vector2 mousePos { get; private set; }

    // Update is called once per frame
    void Update() {
        if (GameManager.instance != null && GameManager.instance.isGameOver) {
            moveLeft = false;
            moveRight = false;
            fire = false;
        }

        moveLeft = Input.GetKey(KeyCode.LeftArrow);
        moveRight = Input.GetKey(KeyCode.RightArrow);

        fire = Input.GetButton(fireButtonName);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Input.GetKey(KeyCode.LeftArrow);
    }
}
