using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 30f;

    private Rigidbody2D rb;

    private EnemyManager eManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        eManager = GetComponent<EnemyManager>();
    }

    void FixedUpdate()
    {
        if (eManager.isHurt || eManager.currentHealth <= 0)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        rb.velocity = new Vector2(moveSpeed * Time.deltaTime, rb.velocity.y);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            SwitchDirections();
        }
    }

    public void SwitchDirections()
    {
        transform.localScale *= new Vector2(-1, 1);
        moveSpeed *= -1;
    }
}
