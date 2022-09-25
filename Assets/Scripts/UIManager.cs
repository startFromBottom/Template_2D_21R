using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // 씬 관리자 관련 코드
using UnityEngine.UI; // UI 관련 코드

public class UIManager: MonoBehaviour {

    private static UIManager me;

    public static UIManager instance {
        get {
            if (me == null) {
                me = FindObjectOfType<UIManager>();
            }

            return me;
        }
    }

    public Text ammoText; // 탄약 표시
    public Text scoreText; // 점수 표시
    public Text healthText; // 남은 체력 표시
    public Text stageText; // 스테이지 표시
    public GameObject gameoverUI; // 게임 오버시 활성화할 UI

    public void UpdateAmmoText(int magAmmo) {
        ammoText.text = "Ammo : " + magAmmo;
    }

    public void UpdateScoreText(int newScore) {
        scoreText.text = "Score : " + newScore;
    }

    public void UpdateHealthText(int health) {
        healthText.text = "Health : " + health;
    }

    public void UpdateStageText(int stage) {
        stageText.text = "Stage : " + stage;
    }
    // 게임 오버 UI 활성화
    public void SetActiveGameoverUI(bool active) {
        gameoverUI.SetActive(active);
    }

    // 게임 재시작
    public void GameRestart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
