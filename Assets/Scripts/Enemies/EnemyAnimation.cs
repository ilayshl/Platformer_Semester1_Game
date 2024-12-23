using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{

    private Animator anim;
    private EnemyMovement eMovement;
    private EnemyAttack eAttack;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        eMovement = GetComponent<EnemyMovement>();
        eAttack = GetComponent<EnemyAttack>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Walk animation
        //anim.SetBool("isMoving", eMovement.moveSpeed!=0);
        //Walk animation direction
        anim.SetFloat("xVelocity", rb.velocity.x);
        //Attack animations
        //anim.SetBool("isAttacking", eAttack.isAttacking);
    }

    public void KillEnemyAnimation(GameObject enemy) {
        anim.SetBool("isDead", true);
        Destroy(enemy, 2);
    }

    public void DamageEnemyAnimation(GameObject enemy) {
        anim.SetBool("isDead", true);
    }
}
