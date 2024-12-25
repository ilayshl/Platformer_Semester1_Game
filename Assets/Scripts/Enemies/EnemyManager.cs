using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int currentHealth;
    [SerializeField] const int totalHealth = 3;
    [SerializeField] int enemyDamage = 2;

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
            eAnimation.DamageEnemyAnimation(gameObject, currentHealth);
        }
    }
