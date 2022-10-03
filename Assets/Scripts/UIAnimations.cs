using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIAnimations : MonoBehaviour
{


    Level level;

    public TextMeshProUGUI textMesh;
    public GameObject calsCounterText;

    //public GameObject starLevelMenu;
    public GameObject levelWinMenu;
    //public GameObject levelLossMenu;


    private void Awake() {
        level = GameObject.Find("Game Controller").GetComponent<Level>();
    }



    private void OnEnable() {
        animateLevelWinUI();
        animateCalsCounter();
    }



    public void animateLevelWinUI() {
        calsCounterText.SetActive(false);

        LeanTween.cancel(levelWinMenu);
        transform.localScale = Vector3.one;       
        LeanTween.scale(levelWinMenu, Vector3.one * 0.5f, 1f).setEasePunch();


    }



    public void animateCalsCounter() {
        calsCounterText.SetActive(true);
        LeanTween.scale(calsCounterText, Vector3.one * 1.5f, 1f).setEasePunch();

        if (Score.currentScore > level.calsToPassLevel) {
            Score.currentScore = level.calsToPassLevel;
        }


        LeanTween.value(Score.currentScore, level.calsToPassLevel,2f)
            .setEasePunch()
            .setOnUpdate(setText);

    }


    public void setText(float value) 
    {
        textMesh.text = value.ToString("F0") + "/" + level.calsToPassLevel.ToString();
    }

}
