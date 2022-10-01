using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour {

    public int stage;

    public void UpdateStage() {
        int currentStage = StageManager.instance.stageProperty;
        print("currentStage == " + currentStage + " stage == " + stage);
        if (stage == currentStage) {
            gameObject.SetActive(true);
        }
        else {
            gameObject.SetActive(false);
        }
    }
    
}
