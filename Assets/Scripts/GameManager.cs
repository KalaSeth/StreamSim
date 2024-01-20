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
    public bool CanWalk;

    public Text ViewsText;
    public Text StreamTimeText;

    public int CurrentViewers, NewViewer, ViewRate;
    public int Cash, NewCash;
    float StreamTimer;
    float Counter;


    public GameObject PauseMenu;
    public GameObject CamZizz;
    public GameObject CamZizzParent;

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
        Counter = 0;

        Invoke("Startthings", Random.Range(10, 15));
    }

    // Update is called once per frame
    void Update()
    {
        Counter += Time.deltaTime;

        if (Counter >= 15 && Counter <= 16)
        {
            
        }

        // Remove Before Build
        if (Input.GetKeyUp(KeyCode.E))
        {
            SwitchingPos(0);
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            SwitchingPos(1);
       
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

    void PauseStream()
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
        if (x <= 0.01f)
        {
            NewViewer = Random.Range(0, ViewRate);
            CurrentViewers = CurrentViewers + NewViewer;
            ViewsText.text = CurrentViewers.ToString();
        }

        StreamTimer += Time.deltaTime;
        int seconds = (int)StreamTimer % 60;
        int minutes = (int)StreamTimer / 60;
        StreamTimeText.text = minutes + ":" + seconds;
    }

    public void NewDonation()
    {
        ChatControl.instance.SuperChatShow(NewCash);
        GotDonation = false;
    }

    public void SwitchingPos(int PosIndex)
    {
        int Index = PosIndex;

        if (Index == 0) // WebCam Mode
        {
            SitCatMode = true;
        }
        else if (Index == 1) // Follow Mode
        {
            SitCatMode = false;
        }

        Instantiate(CamZizz, CamZizzParent.transform);
    }

}
