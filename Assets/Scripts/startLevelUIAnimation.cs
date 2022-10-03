using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class startLevelUIAnimation : MonoBehaviour
{

    public Transform levelMenuTransform;
    public Transform startButtonTransform;

    public TMP_Text objectiveText;
    public TMP_Text levelText;

    public Level level;

    private void Start() 
    {
        moveOutScreen();    
        setObjectiveAndLevelText();
        bringUpAnimate();

    }


    public void moveOutScreen() 
    {
        levelMenuTransform.localPosition = new Vector2(2, -Screen.height);
        startButtonTransform.localPosition = new Vector2(24f, -Screen.height);
    }


    public void bringUpAnimate() 
    {
        //MENU BOX     
        levelMenuTransform.LeanMoveLocalY(47, 0.5f).setEaseOutExpo().delay = 0.1f;
        //START BUTTON      
        startButtonTransform.LeanMoveLocalY(-129f, 0.5f).setEaseOutExpo().delay = 0.3f;

    }


    public void setObjectiveAndLevelText() 
    {    
       //Remember the .text
        objectiveText.text = "Burn " + level.calsToPassLevel + "\n" + "Calories"; ;

        levelText.text = "LEVEL " + level.indexLevel;

    }



}

