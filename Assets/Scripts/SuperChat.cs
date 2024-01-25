using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    bool Eed;
    // Start is called before the first frame update
    void Start()
    {
        //UserIcon.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
        ChatBase.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
        ChatBase.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);

        GameManager.instance.GGAudio[5].Play();
        GameManager.instance.GGAudio[2].Play();

        ProgSllider.maxValue = SuperTimer;
        ProgSllider.value = SuperTimer;

        TaskCounter = Random.Range(10,15);
        Dotask = false;
        Eed = false;
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
        { // Name
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Eed == false)
                {
                    GameManager.instance.GGAudio[3].Play();
                    GameManager.instance.TaskIndex++;
                    GameManager.instance.Counter = 0;
                    GameManager.instance.Switch = true;
                    GameManager.instance.DonationBits.SetActive(false);
                    Destroy(gameObject);
                    GameManager.instance.TaskDone[0] = true;
                    Eed = true;
                }
            }
        }
        else if (GameManager.instance.TaskIndex == 1)
        {// Walk
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Eed == false)
                {
                    GameManager.instance.SwitchingPos(1);
                    ProgSllider.value = 100;
                    Dotask = true;
                    Eed = true;
                }
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
        {// Dance
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Eed == false)
                {
                   
                    GameManager.instance.SwitchingPos(1);
                    GameManager.instance.Triggers[0].SetActive(true);
                    ProgSllider.value = 100;
                    Dotask = true;
                    Eed = true;
                }
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
        {// Sing
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Eed == false)
                {
                    GameManager.instance.SwitchingPos(0);
                    ProgSllider.value = 100;
                    GameManager.instance.GGAudio[4].Play();
                    GameManager.instance.TaskIndex++;
                    GameManager.instance.Counter = 0;
                    GameManager.instance.Switch = true;
                    GameManager.instance.DonationBits.SetActive(false);
                    GameManager.instance.Triggers[1].SetActive(true);
                    
                    Destroy(gameObject);
                    GameManager.instance.TaskDone[3] = true;
                    Eed = true;
                }
            }
        }
        else if (GameManager.instance.TaskIndex == 4)
        {// PizzaMan
            Dotask = Cat_Controller.instance.TargetBool;

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Eed == false)
                {
                    GameManager.instance.Triggers[1].SetActive(true);
                    ProgSllider.value = 100;
                    GameManager.instance.SwitchingPos(1);
                    Eed = true;
                }
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
        {// TV
            Dotask = Cat_Controller.instance.TargetBool;

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Eed == false)
                {
                    ProgSllider.value = 100;
                    GameManager.instance.SwitchingPos(1);
                    GameManager.instance.Triggers[2].SetActive(true);
                    Eed = true;
                }
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
                    Cat_Controller.instance.TargetBool = false;
                    Destroy(gameObject);
                    GameManager.instance.TaskDone[5] = true;
                }
            }
        }
        else if (GameManager.instance.TaskIndex == 6)
        {// Heist   Error on tele
            Dotask = Cat_Controller.instance.TargetBool;

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Eed == false)
                {
                    GameManager.instance.GGAudio[1].Play();
                    ProgSllider.value = 100;
                    GameManager.instance.SwitchingPos(1);
                    GameManager.instance.Triggers[1].SetActive(true);
                
                    Eed = true;
                }
              
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
                    GameManager.instance.Triggers[4].SetActive(false);
                    Cat_Controller.instance.Pizzabox[1].SetActive(false);
                    GameManager.instance.SwitchingPos(0);
                    Cat_Controller.instance.TargetBool = false;
                    GameManager.instance.GGAudio[8].Play();
                    Destroy(gameObject);
                    GameManager.instance.TaskDone[6] = true;
                }
            }
        }
        else if (GameManager.instance.TaskIndex == 7)
        {
            // Susu
            Dotask = Cat_Controller.instance.TargetBool;

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Eed == false)
                {
                    ProgSllider.value = 100;
                    GameManager.instance.SwitchingPos(1);
                    GameManager.instance.Triggers[1].SetActive(true);
                    Eed = true;
                }

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
                    GameManager.instance.Triggers[5].SetActive(false);
                    GameManager.instance.SwitchingPos(0);
                    Cat_Controller.instance.TargetBool = false;
                    GameManager.instance.GGAudio[10].Play();
                    Destroy(gameObject);
                    GameManager.instance.TaskDone[7] = true;
                }
            }
        }
        else if (GameManager.instance.TaskIndex == 8)
        { // Sharee
            Dotask = Cat_Controller.instance.TargetBool;

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Eed == false)
                {
                    ProgSllider.value = 100;
                    GameManager.instance.SwitchingPos(1);
                    GameManager.instance.Triggers[1].SetActive(true);
                    Eed = true;
                }

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
                    GameManager.instance.Triggers[6].SetActive(false);
                    Cat_Controller.instance.Shaee[0].SetActive(false);
                    GameManager.instance.SwitchingPos(0);
                    Cat_Controller.instance.TargetBool = false;
                    Destroy(gameObject);
                    GameManager.instance.TaskDone[8] = true;
                }
            }

        }
        else if (GameManager.instance.TaskIndex == 9)
        { // gamla
            Dotask = Cat_Controller.instance.TargetBool;

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Eed == false)
                {
                    GameManager.instance.GGAudio[1].Stop();
                    GameManager.instance.GGAudio[9].Play();
                    ProgSllider.value = 100;
                    GameManager.instance.SwitchingPos(1);
                    GameManager.instance.Triggers[1].SetActive(true);
                    Eed = true;
                }

            }
            if (Dotask == true)
            {
                TaskCounter -= Time.deltaTime;
                if (TaskCounter <= 0)
                {
                   
                    GameManager.instance.Counter = 0;
                    GameManager.instance.Switch = true;
                    GameManager.instance.DonationBits.SetActive(false);
                    GameManager.instance.Triggers[1].SetActive(false);
                    GameManager.instance.Triggers[3].SetActive(false);
                    GameManager.instance.Triggers[6].SetActive(false);
                    Cat_Controller.instance.Shaee[0].SetActive(false);
                    GameManager.instance.SwitchingPos(0);
                    Cat_Controller.instance.TargetBool = false;
                    Destroy(gameObject);
                    GameManager.instance.TaskDone[9] = true;
                    PlayerPrefs.SetInt("gg", 1);
                    SceneManager.LoadScene(3); 
                    Cursor.lockState = CursorLockMode.Confined;
                    Cursor.visible = true;
                }
            }
        }

        
    }
}
