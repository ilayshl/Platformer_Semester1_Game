using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Playeranim: MonoBehaviour {
    private Animator anim;
    private PlayerMovement pm;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Vector2 playerSpeed;

    void Start() {
        anim=GetComponent<Animator>();
        pm=GetComponent<PlayerMovement>();
        sr=GetComponent<SpriteRenderer>();
        rb=GetComponent<Rigidbody2D>();
    }

    void Update() {
        if(pm.horizontalDir!=0) {
            anim.SetBool("isMoving", true);
            DirectionChanger();
        } else {
            anim.SetBool("isMoving", false);
        }
        if(pm.verticalDir<0) {
            anim.SetBool("isCrouching", true);
        } else {
            anim.SetBool("isCrouching", false);
        }
        anim.SetFloat("yVelocity", rb.velocity.y);

    }

    void DirectionChanger() {
        if(pm.horizontalDir<0) {
            sr.flipX=true;
        } else if(pm.horizontalDir>0) {
            sr.flipX=false;
        }
    }
}
