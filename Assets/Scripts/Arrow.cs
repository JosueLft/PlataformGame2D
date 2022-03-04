using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    private Rigidbody2D rig;
    public float speed;
    public bool isRight;
    public int damage;

    void Start() {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2f);
    }

    void FixedUpdate() {
        if(isRight) {
            rig.velocity = Vector2.right * speed;
        } else {
            rig.velocity = Vector2.left * speed;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Enemy") {
            collision.GetComponent<EnemyPatrolGuy>().Damage(damage);
            Destroy(gameObject);
        }
    }
}