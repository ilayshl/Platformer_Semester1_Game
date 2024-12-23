using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] const int totalHealth = 5;
    [SerializeField] int enemyDamage = 3;
    private int currentHealth;

    private EnemyAnimation eAnimation;
    void Awake()
    {
        eAnimation = GetComponent<EnemyAnimation>();
    }

    private void Start() {
        currentHealth=totalHealth;
    }

    void Update()
    {
        
    }

    public void EnemyHit(int damage) {
        currentHealth-=damage;
        if(currentHealth<=0) {
            eAnimation.KillEnemyAnimation(gameObject);
        } else {
            eAnimation.DamageEnemyAnimation(gameObject);
        }
    }

}
