using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int TaskIndex;
    public string[] TaskChat;

    public bool TPSMode;
    public bool SitCatMode;
    public bool IsPaused;
    public bool GotDonation;
    public bool LowView;
    public bool GameOver;
    public bool CanWalk;
    public bool[] TaskDone;
    public bool Switch;
    

    public bool isDancing;
    public bool isSusu;

    public Text ViewsText;
    public Text StreamTimeText;
    public string BitsText;

    public int CurrentViewers, NewViewer, ViewRate;
    public int Cash, NewCash;
    float StreamTimer;
    public float Counter;
    public float SupTime;

    public GameObject PauseMenu;
    public GameObject CamZizz;
    public GameObject CamZizzParent;
    public GameObject DonationBits;
    public GameObject Cat;
    public GameObject GameOverPanel;

    public GameObject[] Triggers;
   

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        TPSMode = false;
        SitCatMode = true;
        CanWalk = false;
        IsPaused = false;
        GotDonation = false;
        LowView = false;
        GameOver = false;
        Counter = 11;
        TaskIndex = 0;
        Switch = false;
        for (int i = 0; i <= TaskDone.Length-1; i++)
        {
            TaskDone[i] = false;
        }
        Invoke("Startthings", Random.Range(10, 15));
    }

    // Update is called once per frame
    void Update()
    {
        if (Switch == true)
        {
            Counter += Time.deltaTime;

            if (Counter >= Random.Range(10,15))
            {
                TSwitch();
                Switch = false;
            }
        }
       

        if (LowView == true)
        {
            StreamDead();
        }
        // Remove Before Build
        if (Input.GetKeyUp(KeyCode.E))
        {
            //SwitchingPos(0);
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
           // SwitchingPos(1);

        }

        if (SitCatMode == false)
        {
            if (Cat.GetComponent<Rigidbody>().velocity == Vector3.zero)
            {
                if (isDancing == false && isSusu == false)
                {
                    Cat_Controller.instance.CatAnim.SetBool("Walking", false);
                }
            }
            else
            {
                if (isDancing == false && isSusu == false)
                {
                    Cat_Controller.instance.CatAnim.SetBool("Walking", true);
                }
            }
        }


        // Remove Before Build


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseStream();
        }
        LiveViewers();

        if (GotDonation == true)
        {
            NewDonation();
        }
    }

    void Startthings()
    {
        GotDonation = true;
        
    }

    public void StreamDead()
    {
      if (CurrentViewers <= 10)
        {
            GameOver = true;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            GameOverPanel.SetActive(true);
        }
    }

    public void PauseStream()
    {
        IsPaused = !IsPaused;

        if (IsPaused == false)
        {
            PauseMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            LevelSwitcher.instance.StreamResumed();
        }
        else
        {
            PauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            LevelSwitcher.instance.StreamPaused();
        }


    }

    void LiveViewers()
    {
        float x = Random.value;
        if (LowView == false)
        {
            if (x <= 0.01f)
            {
                NewViewer = Random.Range(0, ViewRate);
                CurrentViewers += NewViewer;
                ViewsText.text = CurrentViewers.ToString();
            }
        }else if (LowView == true)
        {
            if (x <= 0.02f)
            {
                NewViewer = -CurrentViewers/2 ;
                CurrentViewers += NewViewer;
                ViewsText.text = CurrentViewers.ToString();
            }
        }

            StreamTimer += Time.deltaTime;
        int seconds = (int)StreamTimer % 60;
        int minutes = (int)StreamTimer / 60;
        StreamTimeText.text = minutes + ":" + seconds;
    }

    public void NewDonation()
    {
       ChatControl.instance.SuperChatShow(NewCash, SupTime);
        
        DonationBitShow();
        GotDonation = false;
    }

    void DonationBitShow()
    {
        DonationBits.SetActive(true);
        DonationBits.GetComponentInChildren<Text>().text = BitsText;

    }

    public void SwitchingPos(int PosIndex)
    {
        int Index = PosIndex;

        if (Index == 0) // WebCam Mode
        {
            SitCatMode = true;
            Cat_Controller.instance.CatAnim.SetTrigger("IsSit"); 
           
        }
        else if (Index == 1) // Follow Mode
        {
            SitCatMode = false;
            Cat_Controller.instance.CatAnim.SetTrigger("idle");
        }

        Instantiate(CamZizz, CamZizzParent.transform);
    }

    void TSwitch()
    {
        NewDonation();
    }

}
