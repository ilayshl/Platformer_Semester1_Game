using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int comboCounter;
    public bool isAttacking = false;
    [SerializeField] private Collider2D jabHitbox, crossHitbox;
    private float hitCooldown=0.4f;
    private float comboCooldown=0.5f;
    private float resetTimer;
    private int attackWindowLimiter=2;
    private bool isMidCombo=false;

    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isAttacking && anim.GetBool("isAirborne")==false)
            {
                isAttacking = true;
                isMidCombo = true;
                comboCounter++;
                resetTimer=0;
                if (comboCounter < 3)
                {
                    //Jab
                    Invoke("ResetJab", hitCooldown);
                    jabHitbox.enabled=true;
                }
                else
                {
                    //Cross
                    Invoke("ResetCross", comboCooldown);
                    crossHitbox.enabled=true;
                }
            }
        }

        if (isMidCombo)
        {
                AttackWindowTimer();
        }
    }

    void ResetJab()
    {
        isAttacking = false;
        jabHitbox.enabled=false;
    }

    void ResetCross()
    {
        comboCounter = 0;
        isAttacking = false;
        crossHitbox.enabled=false;
    }

    void AttackWindowTimer()
    {
        resetTimer += Time.deltaTime;
        if (resetTimer >= attackWindowLimiter)
        {
            resetTimer = 0;
            ResetCross();
            isMidCombo=false;
        }
    }
}
