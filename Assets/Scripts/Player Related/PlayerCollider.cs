using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerCollider: MonoBehaviour {
    public int healthPoints;
    public bool isDead=false;
    public bool isHurt = false;
    [SerializeField] private float hitCooldown = 0.4f;
    private int totalHealth = 6;

    private SpriteRenderer sRenderer;
    private Rigidbody2D rb;

    private void Awake() {
        sRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        healthPoints=totalHealth;    
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Enemy")) {
            if(!isHurt && !isDead){
                TakeHit();
                Invoke("HitCooldownReset", hitCooldown);
            }
        }
    }

    void TakeHit() {
        isHurt=true;
        healthPoints--;
        Debug.Log(healthPoints);
        if(healthPoints<=0) {
            PlayerDeath();
            Debug.Log("You're dead!");
        }
    }

    void HitCooldownReset() {
        isHurt=false;
    }

    void PlayerDeath() {
        isDead=true;
        rb.velocity=Vector2.zero;
        Invoke("RestartScene", 3f);
    }

    void RestartScene() {
        isDead=false;
        gameObject.transform.position = Vector2.zero;
        healthPoints=totalHealth;
        //Application.LoadLevel();
    }
}
