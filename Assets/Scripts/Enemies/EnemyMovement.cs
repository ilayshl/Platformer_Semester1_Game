using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 20f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if anim.getBool("isMoving")=true{}
        rb.velocity=new Vector2(moveSpeed*Time.deltaTime, rb.velocity.y);
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Ground")) {
            SwitchDirections();
        }
    }

    void SwitchDirections() {
        transform.localScale*=new Vector2(-1, 1);
        moveSpeed*=-1;
    }
}
