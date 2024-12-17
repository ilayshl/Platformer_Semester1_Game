using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour {

    public float moveSpeed;
    public float horizontalDir;
    public float verticalDir;
    public bool isJumping = false;
    [SerializeField] int jumpForce = 7;
    [SerializeField] float crouchSlowMultiplier = 1.5f;
    private float moveSpeedMultiplier; //For running animation- how fast will it reach maximum speed
    Rigidbody2D rb;

    void Start() {
        rb=GetComponent<Rigidbody2D>();
    }

    private void Update() {
        InputManagement();
        CheckForJump();
    }

    void FixedUpdate() {
        Move();
    }

    void InputManagement() {
        horizontalDir=Input.GetAxisRaw("Horizontal");
        verticalDir=Input.GetAxisRaw("Vertical");
    }

    void CheckForJump() {
        if(isJumping==false&&verticalDir>0) {
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce), ForceMode2D.Impulse);
            isJumping=true;
            GetComponent<Animator>().SetBool("isAirborne", true);
        }
    }

    void Move() {
        if(verticalDir<0 && isJumping==false) {
            rb.velocity=new Vector2(horizontalDir*moveSpeed/crouchSlowMultiplier, rb.velocity.y);
        } else {
            rb.velocity=new Vector2(horizontalDir*moveSpeed, rb.velocity.y);
        }
        
    }



    private void OnCollisionEnter2D(Collision2D collision) {
        if(isJumping==true) {
            isJumping=false;
            GetComponent<Animator>().SetBool("isAirborne", false);
        }
    }
}
