using UnityEngine;

public class Playeranim: MonoBehaviour {
    private Animator anim;
    private PlayerMovement pMovement;
    private PlayerAttack pAttack;
    private Rigidbody2D rb;
    private Vector2 playerSpeed;
    private PlayerCollider pCollider;

    void Awake() {
        anim=GetComponent<Animator>();
        pMovement=GetComponent<PlayerMovement>();
        pAttack=GetComponent<PlayerAttack>();
        rb=GetComponent<Rigidbody2D>();
        pCollider=GetComponent<PlayerCollider>();
    }

    void Update() {
        //Can player move
        anim.SetBool("isLanding", pMovement.isLanding);
        //Walk animation
        anim.SetBool("isMoving", pMovement.horizontalDir!=0);
        //Crouch animation
        anim.SetBool("isCrouching", pMovement.isCrouching());
        //Walk animation direction
        anim.SetFloat("yVelocity", rb.velocity.y);
        //Jump animation
        anim.SetBool("isAirborne", pMovement.isAirborne);
        //Attack animations
        anim.SetBool("isAttacking", pAttack.isAttacking);
        //Player's health
        anim.SetBool("isHurt", pCollider.isHurt);
        anim.SetBool("isDead", pCollider.isDead);
        //Updates comboCounter in the Animator for the Sequence
        if(pAttack.isAttacking && anim.GetFloat("comboCounter") != pAttack.comboCounter){
        anim.SetFloat("comboCounter", pAttack.comboCounter);
        }
    }    
}
