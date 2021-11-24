using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float moveSpeed;
    float xInput, yInput;

    private Vector3 target;
    Vector2 targetPos;
    
    Rigidbody2D rb;
    SpriteRenderer sp;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    void Start() {
        
    }

    void Update() {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        transform.Translate(xInput * moveSpeed, yInput * moveSpeed, 0);

        topDownMove();
    }

    void topDownMove() {
        rb.velocity = new Vector2(moveSpeed * xInput, moveSpeed * yInput);
    }
}
