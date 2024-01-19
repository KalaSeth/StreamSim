using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SuperChat : MonoBehaviour
{
    [SerializeField] public Image UserIcon;
    [SerializeField] Image ChatBase;
    [SerializeField] public Text UserName;
    [SerializeField] public Text SuperChatText;
    [SerializeField] public Text CashText;
    [SerializeField] public Slider ProgSllider;
    public float SuperTimer;

    // Start is called before the first frame update
    void Start()
    {
        //UserIcon.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
        ChatBase.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
        ChatBase.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
        
       
        

        ProgSllider.maxValue = SuperTimer;
        ProgSllider.value = SuperTimer;

        Destroy(gameObject, SuperTimer);
    }

    private void Update()
    {
        ProgSllider.value -= Time.deltaTime;
    }
}
