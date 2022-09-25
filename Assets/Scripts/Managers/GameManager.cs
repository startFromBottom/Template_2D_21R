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

    private float playTime = 0f;
    private int score = 0;
    private int scoreProperty {
        get {
            return score;
        }

        set {
            score = value;
            UIManager.instance.UpdateScoreText(score);
        }
    }
    
    public bool isGameOver { get; private set; }

    private void Awake() {
        if (instance != this) {
            Destroy(gameObject);
        }
    }
    
    void Start() {
        FindObjectOfType<PlayerHealth>().onDeath += EndGame;
    }

    void Update() {
        playTime += Time.deltaTime;
        UIManager.instance.UpdatePlayTimeText(playTime);
    }
    

    public void AddScore(int newScore) {
        Debug.Assert(newScore >= 0);
        if (!isGameOver) {
            scoreProperty += newScore;
        }
    }

    public void SubtractScore(int newScore) {
        Debug.Assert(newScore >= 0);
        if (!isGameOver && scoreProperty > 0) {
            scoreProperty -= newScore;
        }
    }

    public void EndGame() {
        isGameOver = true;
        UIManager.instance.SetActiveGameoverUI(true);
    }
}
