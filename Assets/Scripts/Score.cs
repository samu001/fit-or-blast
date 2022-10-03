using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;


public class Score : MonoBehaviour {
     
    //Object References
    UIAnimations animationUIManager;
    Level level;
    AdsManager adsManager;

    //Text UI
    public TMP_Text ui_currentScore;
    //public TMP_Text ui_scoreNeeded;

  

    public Player player; // script

    public GameObject spawners;
    public GameObject playerGameObject;
    public bool playerWin;

    public static int currentScore;    //Current Calories
    public int scoreNeededToBeatLevel;





    void Start() {

        //INITIALIZE
        currentScore = 0;
        level = GameObject.Find("Game Controller").GetComponent<Level>();
        animationUIManager = GameObject.Find("Game Controller").GetComponent<UIAnimations>();

        adsManager = GetComponent<AdsManager>();

        playerWin = false;
        scoreNeededToBeatLevel = level.calsToPassLevel;

    }

   

    public void resetScore() {
        currentScore = 0;      
    }


    public void updateCurrentScore() {
        ui_currentScore.text = "Cals: " + currentScore + "/" + level.calsToPassLevel;
        level.checkIfWinConditionsAreMet();
    }



}