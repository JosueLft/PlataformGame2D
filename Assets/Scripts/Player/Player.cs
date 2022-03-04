using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed;
    public float jumpForce;
    public GameObject arrow;
    public Transform firePoint;

    private float movement;
    private bool doubleJump;
    private Rigidbody2D rig;
    private Animator anim;
    private bool isJumping;
    private bool isFire;

    void Start() {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update() {
        Jump();
        BowFire();
    }

    void FixedUpdate() {
        Move();
    }

    void Move() {
        movement = Input.GetAxis("Horizontal");
        
        // adiciona velocidade no corpo do personagem no eixo x e y
        rig.velocity = new Vector2(movement * speed, rig.velocity.y);
        if(movement > 0) {
            if(!isJumping) {
                anim.SetInteger("transition", 1);
            }
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if(movement < 0) {
            if(!isJumping) {
                anim.SetInteger("transition", 1);
            }
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if(movement == 0 && !isJumping && !isFire) {
            anim.SetInteger("transition", 0);
        }
    }

    void Jump() {
        if(Input.GetButtonDown("Jump")) {
            if(!isJumping) {
                anim.SetInteger("transition", 2);
                rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                isJumping = true;
            } else {
                if(doubleJump) {
                    anim.SetInteger("transition", 2);
                    rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
    }

    void BowFire() {
        StartCoroutine(Fire());
    }

    IEnumerator Fire() {
        if(Input.GetKeyDown(KeyCode.E)) {
            isFire = true;
            anim.SetInteger("transition", 3);
            GameObject arrowPrefab = Instantiate(arrow, firePoint.position, firePoint.rotation);

            if(transform.rotation.y == 0) {
                arrowPrefab.GetComponent<Arrow>().isRight = true;
            }
            if(transform.rotation.y == 180) {
                arrowPrefab.GetComponent<Arrow>().isRight = false;
            }

            yield return new WaitForSeconds(0.2f);
            isFire = false;
        }
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if(coll.gameObject.layer == 6) {
            isJumping = false;
        }
    }
}