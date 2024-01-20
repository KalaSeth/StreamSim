using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int TaskIndex;
    public string[] TaskChat;

    public bool TPSMode;
    public bool SitCatMode;
    public bool IsPaused;

    public GameObject PauseMenu;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        TPSMode = false;
        SitCatMode = false;
        IsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SitCatMode = true;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SitCatMode = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseStream();
        }
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
}
