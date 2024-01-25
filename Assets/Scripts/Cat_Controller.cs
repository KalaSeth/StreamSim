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
    public GameObject Gamlaa;
    public GameObject Toilet;

    public float MovSpeed;
    float OffConter = 8;
    bool Pizzaoff;
    public bool TargetBool;
    bool Au;

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
        Pizzaoff = false;
        Au = false;
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

        if (Pizzaoff == true)
        {
            OffConter -= Time.deltaTime;
            if (OffConter <= 0)
            {
                GameManager.instance.Triggers[5].transform.position = Vector3.zero;
               
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
            GameManager.instance.GGAudio[0].Stop();
            TargetBool = true;
            TV[0].SetActive(false);
            TV[1].SetActive(true);
        }

        if (other.gameObject.tag == "Door")
        {
            if (GameManager.instance.TaskIndex == 4)
            {
                if (Au == false)
                {
                    GameManager.instance.GGAudio[6].Play(); 
                }
              Au = true;
                TargetBool = true;
            }
            else if (GameManager.instance.TaskIndex == 6)
            {
                GameManager.instance.Triggers[3].SetActive(false);
                GameManager.instance.Triggers[4].SetActive(true);
                GameManager.instance.SwitchingPos(1);
                gameObject.transform.position = new Vector3(7.71f, 16.309f, 10.44f);
            }
            else if(GameManager.instance.TaskIndex == 7)
            {
                GameManager.instance.Triggers[3].SetActive(false);
                GameManager.instance.Triggers[5].SetActive(true);
                GameManager.instance.SwitchingPos(1);
                gameObject.transform.position = new Vector3(7.71f, 16.309f, 10.44f);
            }
            else if(GameManager.instance.TaskIndex == 8)
            {
                GameManager.instance.GGAudio[2].Play();
                GameManager.instance.Triggers[3].SetActive(false);
                GameManager.instance.Triggers[6].SetActive(true);
                GameManager.instance.SwitchingPos(1);
                gameObject.transform.position = new Vector3(7.71f, 16.309f, 10.44f);
            }
            else if(GameManager.instance.TaskIndex == 9)
            {
               
                GameManager.instance.Triggers[3].SetActive(false);
                GameManager.instance.Triggers[7].SetActive(true);
                GameManager.instance.SwitchingPos(1);
                gameObject.transform.position = Tele[0].transform.position;
            }
           
        }

        if (other.gameObject.tag == "Doorin")
        {
            GameManager.instance.Triggers[1].SetActive(false);
            GameManager.instance.Triggers[3].SetActive(false);
            GameManager.instance.SwitchingPos(1);
            gameObject.transform.position = new Vector3(12.0229f, 1.1619f, 49.648f);

            if (GameManager.instance.TaskIndex == 6)
            {
                
            }else if(GameManager.instance.TaskIndex == 7)
            {
                TargetBool = true;
            }else if(GameManager.instance.TaskIndex == 8)
            {
                GameManager.instance.GGAudio[13].Play();
                TV[2].SetActive(true);
                TargetBool = true;
            }
            else if (GameManager.instance.TaskIndex == 9)
            {
                
                TargetBool = true;
            }
        }

        if (other.gameObject.tag == "Pizza")
        {
            TargetBool = true;
            
            GameManager.instance.Triggers[3].SetActive(true);
            GameManager.instance.Triggers[4].SetActive(false);
            Pizzabox[0].SetActive(false);
            Pizzabox[1].SetActive(true);
        }

        if (other.gameObject.tag == "Toilet")
        {
            //CatAnim.SetTrigger("Susu");
            Pizzaoff = true;
            GameManager.instance.GGAudio[11].Play();
            GameManager.instance.GGAudio[12].Play();
           // GameManager.instance.isSusu = true;
            Toilet.SetActive(true);
        }

        if (other.gameObject.tag == "Share")
        {
            
            GameManager.instance.Triggers[3].SetActive(true);
            Shaee[0].SetActive(true);
            Shaee[1].SetActive(false);
        }

        if (other.gameObject.tag == "Gamla")
        {
            GameManager.instance.Triggers[3].SetActive(true);
            TV[3].SetActive(true); GameManager.instance.GGAudio[3].Play();
            GameManager.instance.GGAudio[14].Play();
            GameManager.instance.GGAudio[14].Play();
            GameManager.instance.GGAudio[15].Play();
            Gamlaa.SetActive(false);
            other.gameObject.transform.position = Vector3.zero;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Dance")
        {
            GameManager.instance.isDancing = false;
            CatAnim.SetTrigger("idle");

        }
        if (other.gameObject.tag == "Toilet")
        {
            Toilet.SetActive(false);
            GameManager.instance.GGAudio[11].Stop();
            GameManager.instance.Triggers[3].SetActive(true);
            //GameManager.instance.isSusu = false;
            CatAnim.SetTrigger("idle");
            
        }
       
    }

}
