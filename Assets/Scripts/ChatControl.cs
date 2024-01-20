using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatControl : MonoBehaviour
{
    public static ChatControl instance;

    public GameObject UserChatPrefab;
    GameObject InstancedUserChat;

    public GameObject SuperChatPrefab;
    public GameObject SuperChatBase;
    GameObject InstancedSuperChat;

    float ChatTimer;

    public Sprite[] RandomIcon;
    string[] MainChat;


    public string[] RandomChat;
    public string[] RandomChat1;
    public string[] RandomChat2;
    public string[] RandomChat3;
    public string[] RandomChat4;
    public string[] RandomChat5;
    public string[] RandomChat6;
    public string[] RandomChat7;
    public string[] RandomChat8;
    public string[] RandomChat9;

    public string[] UserNames;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       

        ChatTimer -= Time.deltaTime;

        if (ChatTimer <= 0)
        {
            LiveUserChat();
            ChatTimer = (.5f);//Random.Range(0.5f, 2.5f));
        }

        CurrentTexting();
    }

    public void SuperChatShow(int Donation)
    {
        int Ammount = Donation;
        InstancedSuperChat = Instantiate(SuperChatPrefab, SuperChatBase.transform).gameObject;
        InstancedSuperChat.GetComponent<SuperChat>().UserName.text = UserNames[Random.Range(0, UserNames.Length)];
        InstancedSuperChat.GetComponent<SuperChat>().SuperChatText.text = GameManager.instance.TaskChat[GameManager.instance.TaskIndex];
        InstancedSuperChat.GetComponent<SuperChat>().UserIcon.sprite = RandomIcon[Random.Range(0, RandomIcon.Length)];
        InstancedSuperChat.GetComponent<SuperChat>().CashText.text = Ammount.ToString();
    }

    public void CurrentTexting()
    {
        if (GameManager.instance.TaskIndex == 0)
        {
            MainChat = RandomChat;
            GameManager.instance.NewCash = Random.Range(15, 50);
            GameManager.instance.BitsText = "Yoyo! use E to interact with all things";

        }else if (GameManager.instance.TaskIndex == 1)
        {
            MainChat = RandomChat1;
            GameManager.instance.NewCash = Random.Range(40, 80);
            GameManager.instance.BitsText = "Remember to get up from chair before using WASD!";
        }
        else if (GameManager.instance.TaskIndex == 2)
        {
            MainChat = RandomChat2;
            GameManager.instance.NewCash = Random.Range(60, 150);
                GameManager.instance.BitsText = "Dance habibi";
        }
        else if (GameManager.instance.TaskIndex == 3)
        {
            MainChat = RandomChat3;
            GameManager.instance.NewCash = Random.Range(100, 200);
            GameManager.instance.BitsText = "You voice is really soothing Bilotha";
        }
        else if (GameManager.instance.TaskIndex == 4)
        {
            MainChat = RandomChat4;
            GameManager.instance.NewCash = Random.Range(150, 200);
            GameManager.instance.BitsText = "Who dared to knock?";
        }
        else if (GameManager.instance.TaskIndex == 5)
        {
            MainChat = RandomChat5; 
            GameManager.instance.NewCash = Random.Range(2000, 3000);
            GameManager.instance.BitsText = "Dance with that award Bilu!";
        }
        else if (GameManager.instance.TaskIndex == 6)
        {
            MainChat = RandomChat6;
            GameManager.instance.NewCash = Random.Range(3500, 4000);
            GameManager.instance.BitsText = "EPIC HEIST MAN!!";
        }
        else if (GameManager.instance.TaskIndex == 7)
        {
            MainChat = RandomChat7;
            GameManager.instance.NewCash = Random.Range(5000, 7000);
            GameManager.instance.BitsText = "Go outside";
        }
        else if (GameManager.instance.TaskIndex == 8)
        {
            MainChat = RandomChat8;
            GameManager.instance.NewCash = Random.Range(10000, 12000);
            GameManager.instance.BitsText = "WOOOOOOOOOOOOOOOO";
        }
        else if (GameManager.instance.TaskIndex == 9)
        {
            MainChat = RandomChat9;
            GameManager.instance.NewCash = Random.Range(10000, 12000);
            GameManager.instance.BitsText = "Break the new Gamla outside";
        }
        
    }

    void LiveUserChat()
    {
        int Index = Random.Range(0,RandomChat.Length);
        int Index2 = Random.Range(0,UserNames.Length);
        InstancedUserChat = Instantiate(UserChatPrefab, gameObject.transform).gameObject;

        InstancedUserChat.GetComponent<UserChat>().UserIcon.sprite = RandomIcon[Random.Range(0, RandomIcon.Length)];
        InstancedUserChat.GetComponent<UserChat>().UserChatText.text = RandomChat[Index];
        InstancedUserChat.GetComponent<UserChat>().UserName.text = UserNames[Index2];
       
    }
}
