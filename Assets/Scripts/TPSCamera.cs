using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCamera : MonoBehaviour
{

    public Transform targetPoint;

    public float moveSpeed = 8f;

    public float rotateSpeed = 3f;

    private void Awake()
    {
        
    }

    private void Start()
    {
       
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetPoint.rotation, rotateSpeed * Time.deltaTime);
    }
}
