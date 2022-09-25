using UnityEngine;
using System.Collections;

public class GameManager
    : MonoBehaviour {

    private static GameManager me;

    public static GameManager instance {

        get {
            if (me == null) {
                me = FindObjectOfType<GameManager>();
            }
            return me;
        }

    }

    private int score = 0;
    public bool isGameOver { get; private set; }

    private void Awake() {
        if (instance != this) {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start() {
        FindObjectOfType<PlayerHealth>().onDeath += EndGame;
    }

    public void AddScore(int newScore) {
        // 게임 오버가 아닌 상태에서만 점수 증가 가능
        if (!isGameOver) {
            score += newScore;
            UIManager.instance.UpdateScoreText(score);
        }
    }

    public void EndGame() {
        isGameOver = true;
        UIManager.instance.SetActiveGameoverUI(true);
    }
}
