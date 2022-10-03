using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leanTweenAnimations : MonoBehaviour
{

    public GameObject player;



    public void StartJumping() {

        //Move it
        player.transform.LeanMoveLocal(new Vector2(-8.6f, -0.54f), 0.85f).setOnComplete(jump);    

    }



    public void jump() {
        //Start Jumping
        player.transform.LeanMoveLocal(new Vector2(-8.6f, 1.55f), 0.9f).setEaseOutQuart().setLoopPingPong();
    }
}
