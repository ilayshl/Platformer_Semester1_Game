using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int currentHealth;
    public bool isHurt;
    [SerializeField] const int totalHealth = 3;
    [SerializeField] AudioClip[] hurtSounds;
    [SerializeField] AudioClip deathSound;
    private const int enemyValue = 1;

    private Animator anim;
    private Rigidbody2D rb;
    private AudioSource audioSource;
    private PlayerAttack pAttack;

    void Awake()
    {
        anim=GetComponent<Animator>();
        rb=GetComponent<Rigidbody2D>();  
        audioSource=GetComponent<AudioSource>();
    }

    private void Start() {
        currentHealth=totalHealth;
    }

    void Update() {
        anim.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Player Attack")&&!isHurt) {
            pAttack=collision.gameObject.GetComponentInParent<PlayerAttack>();
            EnemyHit(pAttack.hitDamage());
        }
    }

    //Enemy takes damage
    public void EnemyHit(int damage) {
        isHurt=true;
        currentHealth-=damage;
            DamageEnemy(currentHealth);
            Invoke("ResetIsHurt", 0.4f);
        }

    //Makes Enemy tangible again
        void ResetIsHurt(){
            isHurt=false;
        }

    //Damages the enemy when hurt. If dead, despawns.
    public void DamageEnemy(int healthPoints) {
        anim.SetInteger("Health", healthPoints);
        //Chckes if enemy is dead
        if(healthPoints<=0 && rb.gravityScale!=0) {
            audioSource.PlayOneShot(deathSound);
            anim.SetBool("isHurt", false);
            anim.SetBool("isDead", true);
            gameObject.GetComponent<Collider2D>().enabled=false;
            //Updates the value of enemies slain in the player's script
            pAttack.gameObject.GetComponent<PlayerInfo>().UpdateEnemiesSlainValue(enemyValue);
            rb.gravityScale=0;
            Destroy(gameObject, 2);
        } else {
            anim.SetBool("isHurt", true);
            Invoke("ResetHurtAnimation", 0.4f);
            audioSource.PlayOneShot(hurtSounds[Random.Range(0, hurtSounds.Length)]);
        }
    }

    private void ResetHurtAnimation() {
        anim.SetBool("isHurt", false);
    }
}
