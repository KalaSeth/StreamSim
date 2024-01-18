using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatControl : MonoBehaviour
{
    public GameObject UserChatPrefab;

    float ChatTimer = 1;
    int TextCount = 0;
    public string[] RandomChat;
   

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
       
    }

    void LiveUserChat()
    {
        int Index = Random.Range(0,RandomChat.Length);
        Instantiate(UserChatPrefab, gameObject.transform).GetComponent<UserChat>().UserChatText.text = RandomChat[Index];
       
    }
}
