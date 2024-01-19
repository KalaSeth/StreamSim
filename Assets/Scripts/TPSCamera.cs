using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCamera : MonoBehaviour
{

    public Transform targetPoint;

    public float moveSpeed = 8f;

    public float rotateSpeed = 3f;

    public Vector3 Offset;

    private void Awake()
    {
        
    }

    private void Start()
    {
       
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, targetPoint.position + Offset, moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetPoint.rotation, rotateSpeed * Time.deltaTime);
    }
}
