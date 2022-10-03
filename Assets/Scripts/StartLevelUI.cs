using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartLevelUI : MonoBehaviour {

    [SerializeField] public GameObject startLevelMenu;
    [SerializeField] private Button startButton;

    public Transform levelMenuTransform;
    public Transform startButtonTransform;


    public GameObject player;
    public GameObject dbSpawner;
    public GameObject foodSpawner;



    private void Awake()
    {
        //Initialize Objects
        player = GameObject.Find("Player");
        dbSpawner = GameObject.Find("Dumbbell Spawner");
        foodSpawner = GameObject.Find("Food Spawner");
    }


    private void Start() 
     {       
        //Deactivate not needed objects
        player.SetActive(false);
        dbSpawner.SetActive(false);
        foodSpawner.SetActive(false);

        //Activate Start Menu
        startLevelMenu.SetActive(true);
    }


    public void startLevel() 
    {
        player.SetActive(true);
        dbSpawner.SetActive(true);
        foodSpawner.SetActive(true);
        startLevelMenu.SetActive(false);
   
    }




}
