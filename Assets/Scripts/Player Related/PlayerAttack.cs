using UnityEngine;

public class PlayerAttack: MonoBehaviour {
    public int comboCounter;
    public bool isAttacking = false;
    [SerializeField] private GameObject attacksObject;
    [SerializeField] AudioClip[] attackSounds;
    private Collider2D jabHitbox, crossHitbox;
    private int attackDamage=1;
    private float hitCooldown = 0.4f;
    private float comboCooldown = 0.5f;
    private float resetTimer;
    private int attackWindowLimiter = 2;
    private bool isMidCombo = false;

    private PlayerCollider pCollider;
    private PlayerMovement pMovement;
    private AudioSource audioSource;

    public int hitDamage() {
        if(comboCounter<3) {
            return attackDamage;
        } else {
            return attackDamage*3;
        }
    }

    void Awake() {
        pCollider=GetComponent<PlayerCollider>();
        pMovement=GetComponent<PlayerMovement>();
        jabHitbox=attacksObject.GetComponent<CapsuleCollider2D>();
        crossHitbox=attacksObject.GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            if(pCollider.isHurt==true || pCollider.isDead==true) { return; }
            if(!isAttacking&&pMovement.isAirborne==false) {
                isAttacking=true;
                isMidCombo=true;
                audioSource.PlayOneShot(attackSounds[comboCounter]);
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

    //The maximum delay between continuous attacks
    void AttackWindowTimer() {
        resetTimer+=Time.deltaTime;
        if(resetTimer>=attackWindowLimiter) {
            resetTimer=0;
            ResetCross();
            isMidCombo=false;
        }
    }
}
