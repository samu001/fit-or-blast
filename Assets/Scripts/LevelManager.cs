using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    
    public Button[] lvlButtons;
    int levelsUnlocked;
    

    void Start() {

        //Disable not unlocked Levels
        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1); //First lvl of world 1

        //Set all buttons to false
        for (int i = 0; i < lvlButtons.Length; i++) {           
                lvlButtons[i].interactable = false;
        }

        //Loop throw the button and set them active while "i" is less than amt of lvls unlooked
        for (int i = 0; i < levelsUnlocked; i++) {
            lvlButtons[i].interactable = true;
        }
    }



    public void loadLevel(string lvlName) {
        SceneManager.LoadScene(lvlName);
    }


}
