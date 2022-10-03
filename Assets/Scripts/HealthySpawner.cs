using System.Collections;
using UnityEngine;

public class HealthySpawner : MonoBehaviour {

    Player player;

    public GameObject dumbbellPrefab;
    public GameObject superDBPreFab;
    public float respawnTime;
    private Vector2 screenBounds;
    private float randomNum;

    void Start() {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(lifeSpawn());

        //Initialize Player Class Instance
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }




    private void Update() {
        if (player.isDead) {
            this.gameObject.SetActive(false);
        }
        else {
            this.gameObject.SetActive(true);
        }
    }

    private void spawnDumbbell() {
        randomNum = Random.Range(1, 10);
        GameObject a;

        if (randomNum >= 1 && randomNum <= 7.4) {
            a = Instantiate(dumbbellPrefab) as GameObject;
            a.transform.position = new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y, screenBounds.y));
        }
        else {
            a = Instantiate(superDBPreFab) as GameObject;
            a.transform.position = new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y, screenBounds.y));
        }
    }



    IEnumerator lifeSpawn() {
        while (true) {
            yield return new WaitForSeconds(respawnTime);
            spawnDumbbell();
        }
    }
}
