using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour {

    public float horizontalDir;
    public float verticalDir;
    public bool isAirborne; //used to communicate with PlayerAnimator
    [SerializeField] float moveSpeed;
    [SerializeField] int jumpForce = 7;
    [SerializeField] float crouchSlowMultiplier = 1.5f; //adjusts moveSpeed when player crouches;
    [SerializeField] Collider2D standingCollider;
    [SerializeField] Collider2D crouchingCollider;
    private bool isTouchingGround; //used for jump resets and ground collider child;
    private bool isJumping = false;
    private Rigidbody2D rb;
    private PlayerAttack pAttack;

    [SerializeField] Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;

    public bool isCrouching(){
        if(verticalDir<0 && isJumping==false)
            return true;
        else
            return false;
    }

    void Awake() {
        rb=GetComponent<Rigidbody2D>();
        pAttack=GetComponent<PlayerAttack>();
    }

    private void Update() {
        InputManagement();
        CheckForJump();
        CheckForGround();
        SwitchDirections();
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
        if(isJumping==false && verticalDir>0 && isTouchingGround==true) {
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce), ForceMode2D.Impulse);
            isJumping=true;
            isTouchingGround=false;
            isAirborne=true;
        }
    }

    //Uses previously set input data to set player's velocity
    void Move() {
        if(isCrouching()) {
            //move slower while crouching
            rb.velocity=new Vector2(horizontalDir*moveSpeed/crouchSlowMultiplier, rb.velocity.y);
            //switches colliders when crouching
            if(!crouchingCollider.isActiveAndEnabled && standingCollider.isActiveAndEnabled) {
                crouchingCollider.enabled=true;
                standingCollider.enabled=false;
            }
        } else {
            rb.velocity=new Vector2(horizontalDir*moveSpeed, rb.velocity.y);
            //switches colliders when standing
            if(crouchingCollider.isActiveAndEnabled && !standingCollider.isActiveAndEnabled) {
                crouchingCollider.enabled=false;
                standingCollider.enabled=true;
            }
        }
        
    }

    //Resets player's jump bool
    void CheckForGround() {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, 0.2f, groundLayer);
        if(colliders.Length > 0) {
            isTouchingGround=true;
        }
    }

    //Flips player's gameObject including hitboxes
    void SwitchDirections(){
    if(horizontalDir < 0 && transform.localScale.x > 0){
        transform.localScale*=new Vector2(-1, 1);
    }else if(horizontalDir > 0 && transform.localScale.x < 0){
        transform.localScale*=new Vector2(-1, 1);
    }
    }

    //Lets Animator know it can switch animations
    private void OnCollisionEnter2D(Collision2D collision) {
        if(isJumping==true) {
            isJumping=false;
            isAirborne=false;
        }
    }
}
