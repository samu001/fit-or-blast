using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameParticles : MonoBehaviour
{


    public Level level;
    public ParticleSystem ps;


    //Confeti
    public void playEndLevelParticles() {
        if (level.isCompleted) {
            ps.Play();
        }
    }

}
