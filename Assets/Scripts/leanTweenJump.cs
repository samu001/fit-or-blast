using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leanTweenJump : MonoBehaviour
{
  
  
    public void StartJumping() {
        transform.LeanMove(new Vector2(13, 173), 1);
    }

}
