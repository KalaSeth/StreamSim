using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_Controller : MonoBehaviour
{
    public static Cat_Controller instance;
    public GameObject Webcam;
    public Camera Cam;

    public GameObject TargetChair;

    public float MovSpeed;

    public Animator CatAnim;

    private void Awake()
    {
        instance = this;
        CatAnim = GetComponent<Animator>();
        CatAnim.SetTrigger("IsSit");
    }

    private void Update()
    {
        if (GameManager.instance.SitCatMode == true)
        {
            Cam.transform.position = Vector3.MoveTowards(Cam.transform.position, Webcam.transform.position, MovSpeed * Time.deltaTime);
            Cam.transform.rotation = Webcam.transform.rotation;
            
            if (GameManager.instance.CanWalk == false)
            {
                gameObject.transform.position = TargetChair.transform.position;
                gameObject.transform.rotation = TargetChair.transform.rotation;
            }
        }

    }
}
