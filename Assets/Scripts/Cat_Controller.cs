using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_Controller : MonoBehaviour
{
    public Animator CatAnim;

    // Start is called before the first frame update
    void Start()
    {
        CatAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            CatAnim.SetBool("Walk", true);
        }else CatAnim.SetBool("Walk", false);

        if (Input.GetKeyDown(KeyCode.E))
        {
            CatAnim.SetTrigger("Punch");
        }
    }
}
