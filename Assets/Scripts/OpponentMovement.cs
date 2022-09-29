using UnityEngine;
using System.Collections;

public class OpponentMovement : MonoBehaviour {

    public Transform duelOpponent;
    public PlayerMovement playerMovement;

    private void Update() {
        Rotate();
        Move();
    }

    private void Rotate() {
        Quaternion playerRotation = playerMovement.player.transform.rotation;
        duelOpponent.transform.rotation = 
            Quaternion.Inverse(playerRotation);
    }

    private void Move() {
        // TODO
        // 구현이 너무 드러나있음 -> 캡슐화 필요
        duelOpponent.transform.position =
            -1 * playerMovement.player.transform.position;
    }
}
