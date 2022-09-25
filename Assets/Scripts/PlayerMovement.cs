using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 3f;

    public Transform player;

    // TODO: flag 변수로 Player / Opponent를 분리하는 것이 맞을까 확인이 필요
    //public bool isOpponent = false;

    Vector2 direction;

    private PlayerInput playerInput;

    // Use this for initialization
    void Start() {
        playerInput = GetComponent<PlayerInput>();
        
    }

    private void Update() {

        moveOrRotate();
    }

    private void moveOrRotate() {

        // move
        if (playerInput.moveLeft) {
            player.transform.position +=
                new Vector3(-1 * Time.deltaTime * moveSpeed, 0, 0);

        } else if (playerInput.moveRight) {
            player.transform.position
                += new Vector3(Time.deltaTime * moveSpeed, 0, 0);
        }

        // update
        else {
            direction = playerInput.mousePos - (Vector2)player.position;
            player.transform.right = direction;
        }

    }

}
