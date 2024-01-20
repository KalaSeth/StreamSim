using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_Controller : MonoBehaviour
{
    GameObject Webcam;

    public float MovSpeed;
    public bool CanWalk;

    private void Update()
    {
       if (CanWalk == false)
        {
            Camera.main.transform.position = Webcam.transform.position;
        }
    }
}
