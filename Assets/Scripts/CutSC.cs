using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSC : MonoBehaviour
{
    public GameObject[] Cs;
    public GameObject T;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("gg", 0) == 0)
        {
            Cs[0].SetActive(true); Invoke("Change", 14);
        }
        else if (PlayerPrefs.GetInt("gg", 0) == 1)
        {
            Invoke("scrollEnab", 16);
            Cs[1].SetActive(true); Invoke("Change", 34);
        }

       
    }

    void scrollEnab()
    {
        T.SetActive(true);
    }
    // Update is called once per frame
    void Change()
    {
        SceneManager.LoadScene(1);
    }
}
