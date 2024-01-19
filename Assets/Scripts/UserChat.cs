using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserChat : MonoBehaviour
{
    [SerializeField] public Image UserIcon;
    [SerializeField] Image ChatBase;
    [SerializeField] public Text UserName;
    [SerializeField] public Text UserChatText;

    // Start is called before the first frame update
    void Start()
    {
      //  UserIcon.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255),255);
        ChatBase.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255),255);
        Destroy(gameObject, 15);
    }

   
}
