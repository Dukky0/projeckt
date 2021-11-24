using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {
    public GameObject bullet;
    public GameObject crosshairs;
    public GameObject playerObject;

    public float bulletSpeed = 50.0f;

    private Vector3 target;
    private Vector2 screenBounds;

    bool hit;

    // Start is called before the first frame update
    void Start() {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update() {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshairs.transform.position = new Vector2(target.x, target.y);

        Vector3 difference = target - playerObject.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if(Input.GetMouseButtonDown(0)) {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            fireBullet(direction, rotationZ);
        }

        if (hit == true) {
            Destroy(bullet.gameObject);
        }
    }

    void fireBullet(Vector2 direction, float rotationZ) {
        GameObject b = Instantiate(bullet) as GameObject;
        b.transform.position = playerObject.transform.position;
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        Destroy(b.gameObject, 2.0f);
        b.tag = "bullet";
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "enemy") {
            hit = true;
        }
    }
}