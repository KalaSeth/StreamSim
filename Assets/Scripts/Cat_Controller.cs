using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_Controller : MonoBehaviour
{
    public static Cat_Controller instance;
    public GameObject Webcam;
    public Camera Cam;
    public Camera CamMain;

    public float MovSpeed;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (GameManager.instance.SitCatMode == true)
        {
           

            Cam.transform.position = Vector3.MoveTowards(Cam.transform.position, Webcam.transform.position, MovSpeed * Time.deltaTime);
            Cam.transform.rotation = Webcam.transform.rotation;
        }
        else
        {
        }
    }
}
