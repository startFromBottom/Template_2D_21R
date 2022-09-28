using UnityEngine;
using System.Collections;

public class StageManager : MonoBehaviour {

    private static StageManager me;
    private int stage;

    public int stageProperty {
        get {
            return stage;
        }
        set {
            stage = value;
            UIManager.instance.UpdateStageText(stage);
        }
    }

    public static StageManager instance {

        get {
            if (me == null) {
                me = FindObjectOfType<StageManager>();
            }
            return me;
        }
    }

    private void Awake() {
        stageProperty = 1;
    }
}