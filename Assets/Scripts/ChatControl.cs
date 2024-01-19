using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatControl : MonoBehaviour
{
    public GameObject UserChatPrefab;
    GameObject InstancedUserChat;

    public GameObject SuperChatPrefab;
    public GameObject SuperChatBase;
    GameObject InstancedSuperChat;

    float ChatTimer = 1;

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

        if (Input.GetKeyDown(KeyCode.Q))
        {
            InstancedSuperChat = Instantiate(SuperChatPrefab, SuperChatBase.transform).gameObject;
            InstancedSuperChat.GetComponent<SuperChat>().UserName.text = UserNames[Random.Range(0, UserNames.Length)];
            InstancedSuperChat.GetComponent<SuperChat>().SuperChatText.text = GameManager.instance.TaskChat[GameManager.instance.TaskIndex];
            InstancedSuperChat.GetComponent<SuperChat>().UserIcon.sprite = RandomIcon[Random.Range(0, RandomIcon.Length)];
        }
       
    }

    public void CurrentTexting()
    {
        if (GameManager.instance.TaskIndex == 0)
        {
            MainChat = RandomChat;
        }else if (GameManager.instance.TaskIndex == 1)
        {
            MainChat = RandomChat1;
        }
        else if (GameManager.instance.TaskIndex == 2)
        {
            MainChat = RandomChat2;
        }
        else if (GameManager.instance.TaskIndex == 3)
        {
            MainChat = RandomChat3;
        }
        else if (GameManager.instance.TaskIndex == 4)
        {
            MainChat = RandomChat4;
        }
        else if (GameManager.instance.TaskIndex == 5)
        {
            MainChat = RandomChat5;
        }
        else if (GameManager.instance.TaskIndex == 6)
        {
            MainChat = RandomChat6;
        }
        else if (GameManager.instance.TaskIndex == 7)
        {
            MainChat = RandomChat7;
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
