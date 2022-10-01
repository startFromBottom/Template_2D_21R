using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

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

    public void GoNextStage() {
        stageProperty += 1;
        // TODO: tage가 증가하는 관련 이펙트가 추가되어야 함
        Stage[] stages = Resources.FindObjectsOfTypeAll<Stage>();
        print(stages.Length);

        for (int i = 0; i < stages.Length; i++) {
            stages[i].UpdateStage();
        }
    }


}