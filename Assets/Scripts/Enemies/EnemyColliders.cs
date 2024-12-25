using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliders : MonoBehaviour
{
    private EnemyManager eManager;
    private PlayerAttack pAttack;

    void Awake()
    {
        eManager = GetComponent<EnemyManager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Player Attack")) {
            pAttack = collision.gameObject.GetComponentInParent<PlayerAttack>();
            eManager.EnemyHit(pAttack.hitDamage());
        }
    }
}
