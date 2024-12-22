using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    private Vector3 lastTargetPosition;

    void Start()
    {
        offset = new Vector3(0, 0, -10);
    }
    void Update()
    {
        transform.position = target.position + offset;
    }
}
