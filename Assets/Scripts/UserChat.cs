using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserChat : MonoBehaviour
{
    [SerializeField] Image UserIcon;
    [SerializeField] Image ChatBase;
    [SerializeField] public Text UserChatText;

    // Start is called before the first frame update
    void Start()
    {
        UserIcon.color = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
        ChatBase.color = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
        Destroy(gameObject, 15);
    }

   
}
