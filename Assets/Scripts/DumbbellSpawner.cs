using System.Collections;
using UnityEngine;

public class DumbbellSpawner : MonoBehaviour {

    Player player;
    public Level level;

    public GameObject[] fitSpawner;


    public float respawnTime;
    private Vector2 screenBounds;
    private int randomNum;

    void OnEnable() {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(lifeSpawn());

        //Initialize Player Class Instance
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

    void Update() {
        if (player.isDead || level.isCompleted) {
            this.gameObject.SetActive(false);
        }
    }

    private void spawnFitItems() {

        //Get a random fit item from Array
        int rn = Random.Range(0, fitSpawner.Length);
           
        GameObject item = Instantiate(fitSpawner[rn]);
       item.transform.position = new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y, screenBounds.y));
      
    }



    IEnumerator lifeSpawn() {
        while (true) {
            yield return new WaitForSeconds(respawnTime);
            spawnFitItems();
        }
    }
}
