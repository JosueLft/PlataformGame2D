using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed;
    public float jumpForce;
    private bool doubleJump;

    private Rigidbody2D rig;
    private Animator anim;
    private bool isJumping;

    void Start() {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update() {
        Move();
        Jump();
    }

    void Move() {
        float movement = Input.GetAxis("Horizontal");
        
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
        if(movement == 0 && !isJumping) {
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

    void OnCollisionEnter2D(Collision2D coll) {
        if(coll.gameObject.layer == 6) {
            isJumping = false;
        }
    }
}