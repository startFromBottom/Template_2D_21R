using UnityEngine;

public class ScoreManager : MonoBehaviour {

    private static ScoreManager me;

    public static ScoreManager instance {
        get {
            if (me == null) {
                me = FindObjectOfType<ScoreManager>();
            }
            return me;
        }
    }

    private int score = 0;
    private int killScore = 100;

    public int ScoreProperty {
        get {
            return score;
        }
        set {
            score = value;
            UIManager.instance.UpdateScoreText(score);
        }
        
    }
    
    public void AddScore(int newScore) {
        Debug.Assert(newScore >= 0);
        if (!GameManager.instance.isGameOver) {
            ScoreProperty += newScore;
        }
    }

    public void AddKillScore() {
        AddScore(killScore);
    }
    
    public void SubtractScore(int newScore) {
        Debug.Assert(newScore >= 0);
        if (!GameManager.instance.isGameOver && ScoreProperty > 0) {
            ScoreProperty -= newScore;
        }
    }

}