using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public Player player;
    public Level level;

    public AudioManager audioManager;
    public GameObject healthySpawner;
    public GameObject foodSpawner;
    private ExplosionBar explosionBar;

    public bool xButtonPressed = false;

    public GameObject HUD;
    public GameObject continueUI;
    public GameObject winUI;
    public GameObject loseUI;
    public GameObject startUI;


    AdsManager adsManager;

    public Button videoButton;


    void Start()
    {
      
        continueUI.SetActive(false);
        winUI.SetActive(false);
        loseUI.SetActive(false);

        adsManager     = GetComponent<AdsManager>();
        explosionBar   = GameObject.Find("Explosion Bar").GetComponent<ExplosionBar>();


    }


    void Update()
    {
       
        if (player.isDead == true && xButtonPressed == false && adsManager.canUserWatchVideo == true) {
            continueUI.SetActive(true);
            
        }
        else if(adsManager.canUserWatchVideo == false && player.isDead == true) {
            loseUI.SetActive(true);
        }
        //If player beats the level show Win UI and play sound
        else if(level.isCompleted == true) {
            winUI.SetActive(true);
        }

        if(player.isDead == true || level.isCompleted || startUI.activeSelf == true) {
            HUD.SetActive(false);
        }else {
            HUD.SetActive(true);
        }

    }



    public void resumePlay() {
       
        player.isDead = false;
        continueUI.SetActive(false);
        winUI.SetActive(false);
        loseUI.SetActive(false);


        player.currentWeight = 2;
        player.GetComponent<Renderer>().enabled = true;

        player.manageColliders();

        //Change this
        //Unfreeze y position
        player.rb.constraints = ~RigidbodyConstraints2D.FreezePositionY;;


        healthySpawner.gameObject.SetActive(true);
        foodSpawner.gameObject.SetActive(true);

        explosionBar.SetInitialValues(2,player.maxWeight);

    }


    public void showLoseUI() {

        xButtonPressed = true;
        continueUI.SetActive(false);
        loseUI.SetActive(true);

    }


    public void reloadLevel() {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }



    public void returnToWorldMenu() {
        SceneManager.LoadScene("World 1 - Level Select");
    }




}
