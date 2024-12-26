using UnityEngine;

public class EnemyColliders : MonoBehaviour
{
    private EnemyManager eManager;
    private EnemyMovement eMovement;
    private PlayerAttack pAttack;

    void Awake()
    {
        eManager = GetComponent<EnemyManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Player Attack") && !eManager.isHurt) {
            pAttack = collision.gameObject.GetComponentInParent<PlayerAttack>();
            eManager.EnemyHit(pAttack.hitDamage());
        }
    }
}
