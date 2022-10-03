using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class loseLevelAnimationUI : MonoBehaviour
{

    public Transform boxTransform;
    public Transform bttnTransform;
    



    private void OnEnable() {
        animateStartUI();
    }


    public void animateStartUI() {
        //MENU BOX
        boxTransform.localPosition = new Vector2(-29f, Screen.height);
        boxTransform.LeanMoveLocalY(52f, 0.5f).setEaseOutExpo().delay = 0.1f;

        //START BUTTON
        bttnTransform.localPosition = new Vector2(6, Screen.height);
        bttnTransform.LeanMoveLocalY(-117f, 0.5f).setEaseOutExpo().delay = 0.4f;

    }



}



