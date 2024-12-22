using UnityEngine;

public class Playeranim: MonoBehaviour {
    private Animator anim;
    private PlayerMovement pMovement;
    private PlayerAttack pAttack;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Vector2 playerSpeed;

    void Awake() {
        anim=GetComponent<Animator>();
        pMovement=GetComponent<PlayerMovement>();
        pAttack=GetComponent<PlayerAttack>();
        sr=GetComponent<SpriteRenderer>();
        rb=GetComponent<Rigidbody2D>();
    }

    void Update() {
        anim.SetBool("isMoving", pMovement.horizontalDir!=0);
        anim.SetBool("isCrouching", pMovement.isCrouching());
        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("isAirborne", pMovement.isAirborne);
        anim.SetBool("isAttacking", pAttack.isAttacking);

        if(pAttack.isAttacking && anim.GetFloat("comboCounter") != pAttack.comboCounter){
        anim.SetFloat("comboCounter", pAttack.comboCounter);
        }
    }    
}
