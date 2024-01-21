using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_Controller : MonoBehaviour
{
    public static Cat_Controller instance;
    public GameObject Webcam;
    public Camera Cam;

    public GameObject TargetChair;
    public GameObject[] Chair;
    public GameObject[] TV;

    public Transform[] Tele;
    public GameObject[] Pizzabox;
    public GameObject[] Shaee;

    public float MovSpeed;

    public bool TargetBool;

    public Animator CatAnim;

    private void Awake()
    {
        instance = this;
        CatAnim = GetComponent<Animator>();
        CatAnim.SetTrigger("IsSit");
    }

    private void Start()
    {
        TargetBool = false;
    }

    public void Update()
    {
       
        if (GameManager.instance.SitCatMode == true)
        {
           
            Cam.transform.position = Vector3.MoveTowards(Cam.transform.position, Webcam.transform.position, MovSpeed * Time.deltaTime);
            Cam.transform.rotation = Webcam.transform.rotation;

            if (GameManager.instance.CanWalk == false)
            {
                Chair[0].transform.position = Chair[1].transform.position;
                gameObject.transform.position = TargetChair.transform.position;
                gameObject.transform.rotation = TargetChair.transform.rotation;
            }
            else if (GameManager.instance.CanWalk == true)
            {
                Chair[0].transform.position = Chair[2].transform.position;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Chair")
        {
            GameManager.instance.SwitchingPos(0);
            GameManager.instance.CanWalk = false;
        }

        if (other.gameObject.tag == "Dance")
        {
            GameManager.instance.isDancing = true;
            CatAnim.SetTrigger("Dance");
        }

        if (other.gameObject.tag == "TV")
        {
            TargetBool = true;
            TV[0].SetActive(false);
            TV[1].SetActive(true);
        }

        if (other.gameObject.tag == "Door")
        {
            if (GameManager.instance.TaskIndex == 4)
            {
                TargetBool = true;
            }
            else if (GameManager.instance.TaskIndex == 6)
            {
                GameManager.instance.Triggers[1].SetActive(false);
                GameManager.instance.Triggers[3].SetActive(true);
                GameManager.instance.SwitchingPos(1);
                gameObject.transform.position = Tele[0].transform.position;
            }
            else if(GameManager.instance.TaskIndex == 7)
            {
                GameManager.instance.Triggers[1].SetActive(false);
                GameManager.instance.Triggers[3].SetActive(true);
                GameManager.instance.SwitchingPos(1);
                gameObject.transform.position = Tele[0].transform.position;
            }else if(GameManager.instance.TaskIndex == 8)
            {
                GameManager.instance.Triggers[1].SetActive(false);
                GameManager.instance.Triggers[3].SetActive(true);
                GameManager.instance.SwitchingPos(1);
                gameObject.transform.position = Tele[0].transform.position;
            }else if(GameManager.instance.TaskIndex == 9)
            {
                GameManager.instance.Triggers[1].SetActive(false);
                GameManager.instance.Triggers[3].SetActive(true);
                GameManager.instance.SwitchingPos(1);
                gameObject.transform.position = Tele[0].transform.position;
            }
           
        }

        if (other.gameObject.tag == "Doorin")
        {
            GameManager.instance.Triggers[1].SetActive(true);
            GameManager.instance.Triggers[3].SetActive(false);
            gameObject.transform.position = Tele[1].transform.position;
        }

        if (other.gameObject.tag == "Pizza")
        {
            TargetBool = true;
            Pizzabox[0].SetActive(true);
            Pizzabox[1].SetActive(false);
        }

        if (other.gameObject.tag == "Toilet")
        {

        }

        if (other.gameObject.tag == "Share")
        {
            TargetBool = true;
            Shaee[0].SetActive(true);
            Shaee[1].SetActive(false);
        }

        if (other.gameObject.tag == "Gamla")
        {

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Dance")
        {
            GameManager.instance.isDancing = false;
            CatAnim.SetTrigger("idle");

        }
    }
}
