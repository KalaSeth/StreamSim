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

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        TPSMode = false;
        SitCatMode = false;
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
    }

   
}
