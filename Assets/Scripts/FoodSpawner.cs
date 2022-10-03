using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour {

    public GameObject[] objects;

    Player player;

    public float respawnTime;
    private Vector2 screenBounds;
    private int randomNum;

    void Start() {

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(foodSpawn());

        //Initialize Player Class Instance
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update() {
        if (player.isDead) {
            this.gameObject.SetActive(false);
        }
    }


    private void spawnFood() {
        randomNum = Random.Range(1, 10);
        GameObject a;

        if (randomNum >= 1 && randomNum <= 5) {
            a = Instantiate(objects[0]) as GameObject;
            a.transform.position = new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y, screenBounds.y));
        }
        else if ((randomNum > 5 && randomNum <= 8)) {
            a = Instantiate(objects[1]) as GameObject;
            a.transform.position = new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y, screenBounds.y));
        }
        else if ((randomNum > 8 && randomNum <= 10)) {
            a = Instantiate(objects[2]) as GameObject;
            a.transform.position = new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y, screenBounds.y));
        }

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
        }
        else if (Score.currentScore > 30) {
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



