using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pie : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private Player player;

    void Start() {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);      
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
