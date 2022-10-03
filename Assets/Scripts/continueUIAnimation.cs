using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class continueUIAnimation : MonoBehaviour
{

    public Transform boxTransform;
    public Transform bttnTransform;

    public TMP_Text objectiveText;
    public Level level;

    private void OnEnable() {
        fillObjectiveText();
        animateStartUI();

    }



    public void animateStartUI() {
        //MENU BOX

        boxTransform.localPosition = new Vector2(-21f, -Screen.height);
        boxTransform.LeanMoveLocalY(33f, 0.5f).setEaseOutExpo().delay = 0.1f;

        //START BUTTON
        bttnTransform.localPosition = new Vector2(14.3f, -Screen.height);
        bttnTransform.LeanMoveLocalY(-142f, 0.5f).setEaseOutExpo().delay = 0.4f;

    }


    public void fillObjectiveText() {
        objectiveText.text = Score.currentScore.ToString("00") + "/" + level.calsToPassLevel;
    }

}
