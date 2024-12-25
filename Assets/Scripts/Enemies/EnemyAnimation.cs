using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{

    private Animator anim;
    private EnemyMovement eMovement;
    private EnemyAttack eAttack;
    private EnemyManager eManager;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        eMovement = GetComponent<EnemyMovement>();
        eAttack = GetComponent<EnemyAttack>();
        eManager = GetComponent<EnemyManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        
        //Attack animations
        //anim.SetBool("isAttacking", eAttack.isAttacking);
    }

    public void DamageEnemyAnimation(GameObject enemy, int healthPoints) {
        anim.SetInteger("Health", healthPoints);
        anim.SetBool("isHurt", true);
        Invoke("ResetHurtAnimation", 0.5f);
        if(healthPoints <= 0) {
            anim.SetBool("isHurt", false);
            anim.SetBool("isDead", true);
            gameObject.GetComponent<Collider2D>().enabled = false;
            rb.gravityScale = 0;
            Destroy(enemy, 2);
        }
    }

    private void ResetHurtAnimation() {
        anim.SetBool("isHurt", false);
    }
}
