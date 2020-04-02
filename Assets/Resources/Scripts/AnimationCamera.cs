using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCamera : MonoBehaviour
{

    public void startAnimation(){
    	GetComponent<Animator>().SetBool("boule", false);
        FindObjectOfType<AudioManager>().Play("Hello");
    }

    public void endAnimation(){
    	GetComponent<Animator>().SetBool("boule", true);
    }
}
