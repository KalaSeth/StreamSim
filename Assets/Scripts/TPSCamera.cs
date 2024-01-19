using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class TPSCamera : MonoBehaviour
{

    public Transform targetPoint;
    public Transform TableTarget;


    public float moveSpeed = 8f;
    public float rotateSpeed = 3f;

    public Vector3 Offset;

    public float sensitivity = 100.0f;
    public float smoothing = 2.0f;
    Vector2 mouseLook;
    Vector2 smoothV;
    GameObject character;

    private void Awake()
    {
        
    }

    private void Start()
    {
         character = transform.gameObject;
    }

    private void LateUpdate()
    {
        //if (GameManager.instance.TPSMode == true)
        {
            FollowPlayer();
        }//else
        {
          //  transform.position = Vector3.Lerp(transform.position, TableTarget.position, moveSpeed * Time.deltaTime);
        }
       
    }

    void FollowPlayer()
    {
        transform.position = Vector3.Lerp(transform.position, targetPoint.position + Offset, moveSpeed * Time.deltaTime);
        //  transform.rotation = Quaternion.Lerp(transform.rotation, targetPoint.rotation, rotateSpeed * Time.deltaTime);

        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -20f, 20f);
        transform.localRotation = Quaternion.AngleAxis(mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }
}
