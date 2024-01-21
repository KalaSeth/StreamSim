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

    float TaskCounter;
    bool Dotask;

    // Start is called before the first frame update
    void Start()
    {
        //UserIcon.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
        ChatBase.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
        ChatBase.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
        
       
        

        ProgSllider.maxValue = SuperTimer;
        ProgSllider.value = SuperTimer;

        TaskCounter = Random.Range(10,15);
        Dotask = false; 
    }

    private void Update()
    {
        
        ProgSllider.value -= Time.deltaTime;

        if (ProgSllider.value > 0)
        {
            if (GameManager.instance.TaskDone[GameManager.instance.TaskIndex] == true)
            {
                GameManager.instance.TaskIndex++;
                GameManager.instance.Counter = 0;
                GameManager.instance.Switch = true;
                GameManager.instance.DonationBits.SetActive(false);
                Destroy(gameObject);
            }
        }
        else if (ProgSllider.value <= 1) GameManager.instance.LowView = true;


        if (GameManager.instance.TaskIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameManager.instance.TaskIndex++;
                GameManager.instance.Counter = 0;
                GameManager.instance.Switch = true;
                GameManager.instance.DonationBits.SetActive(false);
                Destroy(gameObject);
                GameManager.instance.TaskDone[0] = true;
            }
        }
        else if (GameManager.instance.TaskIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameManager.instance.SwitchingPos(1);
                ProgSllider.value = 100;
                Dotask = true;
            }
            if (Dotask == true)
            {
                TaskCounter -= Time.deltaTime;
                if (TaskCounter <= 0)
                {
                    GameManager.instance.TaskIndex++;
                    GameManager.instance.Counter = 0;
                    GameManager.instance.Switch = true;
                    GameManager.instance.DonationBits.SetActive(false);
                    Destroy(gameObject);
                    GameManager.instance.TaskDone[1] = true;
                }
            }
        }
        else if (GameManager.instance.TaskIndex == 2)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameManager.instance.SwitchingPos(1);
                GameManager.instance.Triggers[0].SetActive(true);
                ProgSllider.value = 100;
                Dotask = true;
            }
            if (Dotask == true)
            {
                TaskCounter -= Time.deltaTime;
                if (TaskCounter <= 0)
                {
                    GameManager.instance.TaskIndex++;
                    GameManager.instance.Counter = 0;
                    GameManager.instance.Switch = true;
                    GameManager.instance.DonationBits.SetActive(false);
                    GameManager.instance.Triggers[0].SetActive(false);
                    GameManager.instance.SwitchingPos(0);
                    GameManager.instance.isDancing = false;
                    Destroy(gameObject);
                    GameManager.instance.TaskDone[2] = true;
                }
            }
        }
        else if (GameManager.instance.TaskIndex == 3)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameManager.instance.SwitchingPos(0);
                ProgSllider.value = 100;
           
                    GameManager.instance.TaskIndex++;
                    GameManager.instance.Counter = 0;
                    GameManager.instance.Switch = true;
                    GameManager.instance.DonationBits.SetActive(false);
                GameManager.instance.Triggers[1].SetActive(true);
                Destroy(gameObject);
                    GameManager.instance.TaskDone[3] = true;
                
            }
        }
        else if (GameManager.instance.TaskIndex == 4)
        {
            Dotask = Cat_Controller.instance.TargetBool;

            if (Input.GetKeyDown(KeyCode.E))
            {
                GameManager.instance.SwitchingPos(1);             
            }
            if (Dotask == true)
            {
                TaskCounter -= Time.deltaTime;
                if (TaskCounter <= 0)
                {
                    GameManager.instance.TaskIndex++;
                    GameManager.instance.Counter = 0;
                    GameManager.instance.Switch = true;
                    GameManager.instance.DonationBits.SetActive(false);
                    GameManager.instance.Triggers[1].SetActive(false);
                    GameManager.instance.SwitchingPos(0);
                    Cat_Controller.instance.TargetBool = false;
                    Destroy(gameObject);
                    GameManager.instance.TaskDone[4] = true;
                }
            }
        }
        else if (GameManager.instance.TaskIndex == 5)
        {
            Dotask = Cat_Controller.instance.TargetBool;

            if (Input.GetKeyDown(KeyCode.E))
            {
                GameManager.instance.SwitchingPos(1);
                GameManager.instance.Triggers[2].SetActive(true);
            }
            if (Dotask == true)
            {
                TaskCounter -= Time.deltaTime;
                if (TaskCounter <= 0)
                {
                    GameManager.instance.TaskIndex++;
                    GameManager.instance.Counter = 0;
                    GameManager.instance.Switch = true;
                    GameManager.instance.DonationBits.SetActive(false);
                    GameManager.instance.Triggers[2].SetActive(false);
                    GameManager.instance.SwitchingPos(0);
                    Destroy(gameObject);
                    GameManager.instance.TaskDone[5] = true;
                }
            }
        }
        else if (GameManager.instance.TaskIndex == 6)
        {
            Dotask = Cat_Controller.instance.TargetBool;

            if (Input.GetKeyDown(KeyCode.E))
            {
                GameManager.instance.SwitchingPos(1);
                GameManager.instance.Triggers[1].SetActive(true);
                GameManager.instance.Triggers[3].SetActive(true);
            }
            if (Dotask == true)
            {
                TaskCounter -= Time.deltaTime;
                if (TaskCounter <= 0)
                {
                    GameManager.instance.TaskIndex++;
                    GameManager.instance.Counter = 0;
                    GameManager.instance.Switch = true;
                    GameManager.instance.DonationBits.SetActive(false);
                    GameManager.instance.Triggers[1].SetActive(false);
                    GameManager.instance.Triggers[3].SetActive(false);
                    GameManager.instance.SwitchingPos(0);
                    Destroy(gameObject);
                    GameManager.instance.TaskDone[6] = true;
                }
            }
        }
        else if (GameManager.instance.TaskIndex == 7)
        {

        }
        else if (GameManager.instance.TaskIndex == 8)
        {

        }
        else if (GameManager.instance.TaskIndex == 9)
        {

        }

        
    }
}
