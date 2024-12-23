using UnityEngine;

public class PlayerCollider: MonoBehaviour {
    [SerializeField] private float hitCooldown = 0.7f;
    private bool isHit = false;

    private SpriteRenderer sRenderer;
    private Rigidbody2D rb;

    private void Awake() {
        sRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Enemy")) {
            if(!isHit){
                Debug.Log("take hit");
                TakeHit();
                Invoke("HitCooldownReset", hitCooldown);
            }
        }
    }

    void TakeHit() {
        isHit=true;
        sRenderer.color=Color.red;
        Debug.Log("took a hit");
        //hp--
    }

    void HitCooldownReset() {
        isHit=false;
        sRenderer.color=Color.white;
        Debug.Log("can take damage again");
    }
}
