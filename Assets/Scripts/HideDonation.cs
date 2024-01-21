using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideDonation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeInHierarchy == true)
        {
            Invoke("hida", 10);
        }
    }

    void hida()
    {
        gameObject.SetActive(false);
    }
}
