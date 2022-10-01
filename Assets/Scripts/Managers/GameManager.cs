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
    public bool isGameOver { get; private set; }

    private void Awake() {
        if (instance != this) {
            Destroy(gameObject);
        }
    }
    
    void Start() {
        AddDeathEvent();
    }

    void Update() {
        playTime += Time.deltaTime;

        if (!isGameOver) {
            UIManager.instance.UpdatePlayTimeText(playTime);
        }
    }
    
    public void EndGame() {
        isGameOver = true;
        UIManager.instance.SetActiveGameoverUI(true);
    }

    private void AddDeathEvent() {
        FindObjectOfType<PlayerHealth>().onDeath += EndGame;
        FindObjectOfType<OpponentHealth>().onDeath += ScoreManager.instance.AddKillScore;
        FindObjectOfType<OpponentHealth>().onDeath += StageManager.instance.GoNextStage;
    }

}
