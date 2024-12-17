using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour {

    public float horizontalDir;
    public float verticalDir;
    public bool isJumping = false;
    [SerializeField] float moveSpeed;
    [SerializeField] int jumpForce = 7;
    [SerializeField] float crouchSlowMultiplier = 1.5f; //adjusts moveSpeed when player crouches;
    [SerializeField] Collider2D standingCollider;
    [SerializeField] Collider2D crouchingCollider;
    private bool isTouchingGround; //used for jump resets and ground collider child;
    Rigidbody2D rb;


    //Collider
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;

    void Start() {
        rb=GetComponent<Rigidbody2D>();
    }

    private void Update() {
        InputManagement();
        CheckForJump();
        CheckForGround();
    }

    void FixedUpdate() {
        Move();
    }

    //Passes current input information to other methods
    void InputManagement() {
        horizontalDir=Input.GetAxisRaw("Horizontal");
        verticalDir=Input.GetAxisRaw("Vertical");
    }

    //Player jumps only if it is not jumping already AND Y input is pressed
    void CheckForJump() {
        if(isJumping==false&&verticalDir>0&&isTouchingGround==true) {
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce), ForceMode2D.Impulse);
            isJumping=true;
            isTouchingGround=false;
            GetComponent<Animator>().SetBool("isAirborne", true);
        }
    }

    //Uses previously set input data to set player's velocity
    void Move() {
        if(verticalDir<0 && isJumping==false) {
            rb.velocity=new Vector2(horizontalDir*moveSpeed/crouchSlowMultiplier, rb.velocity.y);
        } else {
            rb.velocity=new Vector2(horizontalDir*moveSpeed, rb.velocity.y);
        }
        
    }

    //Resets player's jump bool
    void CheckForGround() {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, 0.2f, groundLayer);
        if(colliders.Length > 0) {
            isTouchingGround=true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(isJumping==true) {
            isJumping=false;
            GetComponent<Animator>().SetBool("isAirborne", false);
        }
    }
}
