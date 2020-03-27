using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleControl : MonoBehaviour
{

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            anim.SetBool("boule", true);
            FindObjectOfType<AudioManager>().Play("Hello");
        }
        else
        {
            anim.SetBool("boule", false);
        }
    }
}
