using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeatingBackGround : MonoBehaviour
{

    private BoxCollider2D backgroundCollider;
    private float BackgroundSize;
    private Rigidbody2D RIGIDBODY;

    [SerializeField] private float Speed;

    void Start() {
        backgroundCollider = GetComponent<BoxCollider2D>();
        BackgroundSize = backgroundCollider.size.x;

        Speed = -Speed;
        RIGIDBODY = GetComponent<Rigidbody2D>();
        RIGIDBODY.velocity = new Vector2(Speed, 0);
    }


    void Update() {
        if (transform.position.x < -BackgroundSize) {
            RepeatBackground();
        }
    }


    void RepeatBackground() {
        Vector2 BGoffset = new Vector2(BackgroundSize * 2f, 0);
        transform.position = (Vector2)transform.position + BGoffset;
    }








}
