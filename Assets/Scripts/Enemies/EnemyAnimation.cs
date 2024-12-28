using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{

    private Animator anim;
    private EnemyMovement eMovement;
    private EnemyManager eManager;
    private Rigidbody2D rb;

    void Awake()
    {
        anim = GetComponent<Animator>();
        eMovement = GetComponent<EnemyMovement>();
        eManager = GetComponent<EnemyManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        anim.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
    }

    public void DamageEnemyAnimation(GameObject enemy, int healthPoints) {
        anim.SetInteger("Health", healthPoints);
        anim.SetBool("isHurt", true);
        Invoke("ResetHurtAnimation", 0.4f);
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
