using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieSpawner : MonoBehaviour {

   
    Player player;
    public Level level;

    public GameObject[] foodItems;

    public float respawnTime;
    private Vector2 screenBounds;
    private int randomNum;




    void OnEnable() {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(foodSpawn());


        //Initialize Player Class Instance
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }





    private void Update() {
        if (player.isDead || level.isCompleted) {
            this.gameObject.SetActive(false);
        }
        else if (player.isDead == false) {
            this.gameObject.SetActive(true);
        }
      





    }


    private void spawnFood() {

        int rn = Random.Range(0, foodItems.Length);

        
        GameObject foodItem = Instantiate(foodItems[rn]);
        foodItem.transform.position = new Vector2(screenBounds.x * 1.5f, Random.Range(-screenBounds.y, screenBounds.y));

    }





    private void changeRespawnTime() {
       if (Score.currentScore >= 5 && Score.currentScore <= 10) {
            respawnTime = 0.85f;
        }
        else if (Score.currentScore > 10 && Score.currentScore <= 20) {
            respawnTime = 0.7f;
        }        
        else if (Score.currentScore > 20 && Score.currentScore <= 30) {
            respawnTime = 0.65f;
        } else if (Score.currentScore > 30) {
            respawnTime = 0.6f;
        }

    }


        IEnumerator foodSpawn() {
            while (true) {
                yield return new WaitForSeconds(respawnTime);
                spawnFood();
                changeRespawnTime();
            }
        }
    }



