using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImgLooper : MonoBehaviour
{
    public Sprite[] Img;
    float Index = 0;

    private void Start()
    {
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        Index++;
        if (Index >= Img.Length - 1)
        {
          
            Index = 0;
        }
        gameObject.GetComponent<Image>().sprite = Img[(int)Index];
    }
}
