using UnityEngine;

public class PlayerAttack: MonoBehaviour {
    public int comboCounter;
    public bool isAttacking = false;
    [SerializeField] private GameObject attacksObject;
    private Collider2D jabHitbox, crossHitbox;
    private int attackDamage=1;
    private float hitCooldown = 0.4f;
    private float comboCooldown = 0.5f;
    private float resetTimer;
    private int attackWindowLimiter = 2;
    private bool isMidCombo = false;

    private PlayerCollider pCollider;

    private Animator anim;

    public int hitLands() {
        if(comboCounter<3) {
            return attackDamage;
        } else {
            return attackDamage*3;
        }
    }

    void Awake() {
        anim=GetComponent<Animator>();
        pCollider=GetComponent<PlayerCollider>();
        jabHitbox=attacksObject.GetComponent<CapsuleCollider2D>();
        crossHitbox=attacksObject.GetComponent<BoxCollider2D>();
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            if(pCollider.isHurt==true || pCollider.isDead==true) { return; }
            if(!isAttacking&&anim.GetBool("isAirborne")==false) {
                isAttacking=true;
                isMidCombo=true;
                comboCounter++;
                resetTimer=0;
                if(comboCounter<3) {
                    //Jab
                    Invoke("ResetJab", hitCooldown);
                    jabHitbox.enabled=true;
                } else {
                    //Cross
                    Invoke("ResetCross", comboCooldown);
                    crossHitbox.enabled=true;
                }
            }
        }

        if(isMidCombo) {
            AttackWindowTimer();
        }
    }

    void ResetJab() {
        isAttacking=false;
        jabHitbox.enabled=false;
    }

    void ResetCross() {
        comboCounter=0;
        isAttacking=false;
        crossHitbox.enabled=false;
    }

    void AttackWindowTimer() {
        resetTimer+=Time.deltaTime;
        if(resetTimer>=attackWindowLimiter) {
            resetTimer=0;
            ResetCross();
            isMidCombo=false;
        }
    }
}
