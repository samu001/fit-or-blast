using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
   

    [HideInInspector] public int  sceneIndex;
    public AudioManager audioManager;
    [HideInInspector] public bool isCompleted;

    public int indexLevel;
    public int calsToPassLevel;

    public EndGameParticles endParticles;

    leanTweenAnimations leanTweenAnim;
    
    public void Awake()
    {
        //getLevelIndex();
        //setWinningConditionsForLevel();
        leanTweenAnim = GetComponent<leanTweenAnimations>();

    }


    public void checkIfWinConditionsAreMet() {

       
        //PLAYER WINS
        if(Score.currentScore >= calsToPassLevel) {
            isCompleted = true;
            unlockNewLevelsIfNeeded();
            leanTweenAnim.StartJumping();
            audioManager.Play("win level");
            endParticles.playEndLevelParticles();
        }
    }


    private void unlockNewLevelsIfNeeded() 
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;                       
        if(currentLevel >= PlayerPrefs.GetInt("levelsUnlocked")) { 
            PlayerPrefs.SetInt("levelsUnlocked", currentLevel + 1);
        }     
    }




}
