using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int currentHealth;
    public bool isHurt;
    [SerializeField] const int totalHealth = 3;

    private EnemyAnimation eAnimation;
    void Awake()
    {
        eAnimation = GetComponent<EnemyAnimation>();
    }

    private void Start() {
        currentHealth=totalHealth;
    }
    public void EnemyHit(int damage) {
        isHurt=true;
        currentHealth-=damage;
            eAnimation.DamageEnemyAnimation(gameObject, currentHealth);
            Invoke("ResetIsHurt", 0.6f);
        }

        void ResetIsHurt(){
            isHurt=false;
        }
    }
