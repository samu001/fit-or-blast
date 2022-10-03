using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private Player player;

    void Start() {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        
        rb = this.GetComponent<Rigidbody2D>(); // initialize rb variable to the rigidBody2d of this object
        rb.velocity = new Vector2(-speed, 0);

        //Define the boundaries of screen on x and y axis and store into vector2 screenBounds variable
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update() {
        if (transform.position.x < -screenBounds.x * 2 || player.isDead) {
            Destroy(this.gameObject);
        }    
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Power") {
            Destroy(this.gameObject);
        }
    }


}