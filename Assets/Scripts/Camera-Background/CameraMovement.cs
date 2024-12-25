using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    void Start()
    {
        offset = new Vector3(0, 0, -10);
    }
    void Update()
    {
        transform.position = target.position + offset;
    }

    public void SetTarget(GameObject newTarget, Vector3 newOffset) {
        target = newTarget.transform;
        if(newOffset==Vector3.zero){ newOffset=new Vector3(0, 0, -10); }
        offset=newOffset;
    }
}
