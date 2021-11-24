using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    public GameObject bullet;

    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    bool bulletHit;

    // Start is called before the first frame update
    void Start() {
        rb = this.GetComponent<Rigidbody2D>();
        gameObject.tag = "enemy";
    }

    // Update is called once per frame
    void Update() {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;

        if (bulletHit == true) {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D trigger) {
        if (trigger.gameObject.tag == "bullet") {
            bulletHit = true;
        }
    }

    void FixedUpdate() {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction) {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

}
