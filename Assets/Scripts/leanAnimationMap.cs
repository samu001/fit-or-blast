using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leanAnimationMap : MonoBehaviour
{

    public GameObject character;
    public GameObject cookie;
    public GameObject text;



    void Start()
    {
        jump();
    }


    public void jump() {
        LeanTween.move(character.GetComponent<RectTransform>(),
        new Vector3(86.4f, -48.5f, 0f), 0.9f).setEaseOutQuart().setLoopPingPong();

        LeanTween.move(cookie.GetComponent<RectTransform>(),
        new Vector3(-78f, -49f, 0f), 0.9f).setEaseOutQuart().setLoopPingPong().setDelay(0.4f);




    }




}
