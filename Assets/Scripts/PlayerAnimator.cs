using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Playeranim : MonoBehaviour
{
    private Animator anim;
    private PlayerMovement pm;
    private SpriteRenderer sr;

    void Start()
    {
        anim = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (pm.moveDir.x != 0 || pm.moveDir.y != 0)
        {
            anim.SetBool("isMoving", true);
            DirectionChanger();
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }

    void DirectionChanger()
    {
        if (pm.moveDir.x < 0)
        {
            sr.flipX = true;
        }
        else if (pm.moveDir.x > 0)
        {
            sr.flipX = false;
        }
    }
}
